using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Core.Models.Chat;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace CarStore.Services.Chat
{
    public class ChatClient : IChatService
    {
        private const string ServerAddress = "127.0.0.1";
        private const int InitialServerPort = 3001;
        private static TcpClient client;
        private static NetworkStream stream;
        private static int dynamicPort;

        private int userId {get; set;}
        private static List<ChatItem> Chats {get; set;}
        private static List<Message> Messages {get; set;}




        private static async Task ConnectToInitialServer()
        {
            client = new TcpClient();
            client.ConnectAsync(ServerAddress, InitialServerPort).Wait();
            stream = client.GetStream();

            byte[] data = new byte[1024];
            int bytes = await stream.ReadAsync(data, 0, data.Length);
            var portMessage = Encoding.UTF8.GetString(data, 0, bytes);
            if (int.TryParse(portMessage, out dynamicPort))
            {
                ConnectToDynamicPort().Wait();
            }
        }
        private static async Task ConnectToDynamicPort()
        {
            client.Close();
            client = new TcpClient();
            client.ConnectAsync(ServerAddress, dynamicPort).Wait();
            stream = client.GetStream();
        }



        private static async Task<string> SendToServer(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.WriteAsync(data, 0, data.Length).Wait();

            data = new byte[1024];
            int bytes = await stream.ReadAsync(data, 0, data.Length);
            return Encoding.UTF8.GetString(data, 0, bytes);
        }

        //---------------------------------------------------------------
        public ChatClient(int userId)
        {
            this.userId = userId;
            Chats = new List<ChatItem>();
            Messages = new List<Message>();
        }

        private static async Task ListConversations(string userId)
        {
            var message = $"LIST {userId}|EOM|";

            var response = await SendToServer(message);

            try
            {
                var conversations = JsonSerializer.Deserialize<List<Conversation>>(response);
                foreach (var conversation in conversations)
                {
                    ChatItem tmp = new ChatItem
                    {
                        Id = int.Parse(conversation.OtherUserId),
                        personName = conversation.OtherUserId,
                        lastMessage = conversation.LastMessage
                    };
                    Chats.Add(tmp);
                }
            }
            catch (JsonException ex)
            {
                throw;
            }
        }

        private static async Task Exit()
        {
            var message = "EXIT|EOM|";
            await SendToServer(message);
            client.Close();
        }


        public void SendMessage(Message message) => throw new NotImplementedException();

        public List<ChatItem> GetConversations()
        {
            var userId = this.userId.ToString("D6");
            Chats = new List<ChatItem>();
            ConnectToInitialServer().Wait();
            ListConversations(userId).Wait();
            Exit().Wait();
            return Chats;
        }

        public ObservableCollection<Message> GetMessages(int userID) => throw new NotImplementedException();
        public ObservableCollection<ChatItem> GetChatItems() => throw new NotImplementedException();
    }

    public class Conversation
    {
        public string OtherUserId
        {
            get; set;
        }
        public string LastMessage
        {
            get; set;
        }
    }
}

