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
using Microsoft.VisualBasic;

namespace CarStore.Services.Chat
{
    class ChatClient : IChatService
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
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(ServerAddress, InitialServerPort);
                stream = client.GetStream();

                byte[] data = new byte[1024];
                int bytes = await stream.ReadAsync(data, 0, data.Length);
                var portMessage = Encoding.UTF8.GetString(data, 0, bytes);

                if (int.TryParse(portMessage, out dynamicPort))
                {
                    await ConnectToDynamicPort();
                }
                else
                {
                    throw new Exception("Failed to receive a valid port from the server.");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private static async Task ConnectToDynamicPort()
        {
            try
            {
                client.Close();
                client = new TcpClient();
                await client.ConnectAsync(ServerAddress, dynamicPort);
                stream = client.GetStream();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private static async Task SendMessage(int sourceUserID, int targetUserID, string messageContent)
        {
            var message = $"SEND {sourceUserID} {targetUserID} {messageContent}|EOM|";
            await SendToServer(message);
        }
        private static async Task<string> SendToServer(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(data, 0, data.Length);

            data = new byte[1024];
            int bytes = await stream.ReadAsync(data, 0, data.Length);
            return Encoding.UTF8.GetString(data, 0, bytes);
        }

        //---------------------------------------------------------------
        public ChatClient(int userId)
        {
            ConnectToInitialServer().Wait();
            this.userId = userId;
            Chats = new List<ChatItem>();
        }


        public ObservableCollection<ChatItem> GetChatItems()
        {
            string userID = userId.ToString("D6");
            ListConversations(userID).Wait();
            return new ObservableCollection<ChatItem>(Chats);
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



        public ObservableCollection<Message> GetMessages(int userID)
        {
            ReadMessages(this.userId.ToString("D6"),userID.ToString("D6")).Wait();
            return new ObservableCollection<Message>(Messages);
        }
        private static async Task ReadMessages(string userId,string targetUserId)
        {
            var userId1 = userId;
            var userId2 = targetUserId;

            var message = $"RECV {userId1} {userId2}|EOM|";
            var response = await SendToServer(message);

            try
            {
                var messages = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(response);
                foreach (var msg in messages)
                {
                    Message tmp = new Message
                    {
                        Text = msg["message"],
                        isMine = msg["user"] == userId
                    };
                    Messages.Add(tmp);
                }
            }
            catch (JsonException ex)
            {
                throw;
            }
        }


        public void SendMessage(Message message) => throw new NotImplementedException();
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

