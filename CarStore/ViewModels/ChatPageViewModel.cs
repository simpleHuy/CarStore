using CarStore.Core.Models.Chat;
using CarStore.Models.AI;
using CarStore.Services.Chat;
using CarStore.ViewModels;
using CarStore;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;
using CarStore.Core.Models;
using System.Text.Json;
using System.Drawing.Text;
using CarStore.Core.Contracts.Services;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using CarStore.Contracts.Services;
using Microsoft.UI.Dispatching;
using CommunityToolkit.WinUI;

namespace CarStore.ViewModels;

public class ChatPageViewModel : ObservableRecipient, INotifyPropertyChanged
{
    //Chat server
    private const string ServerAddress = "127.0.0.1";
    private const int InitialServerPort = 3001;
    private static TcpClient client;
    private static NetworkStream stream;
    private static int dynamicPort;
    private bool isReload = false;
    private readonly Timer timer;
    public readonly IDao<User> _user;
    public bool isConnectedToServer = true;
    public bool isErrorOccurred = false;
    private ListView _messageListView;
    private readonly IAuthenticationService authenticationService;

    //Gemini API
    private static string GEMINI_API_KEY = "AIzaSyCsJR_KT5o6VrmTCvhoVK8xpIuv5TIBGN4";
    public GeminiChatbot gemini = new(GEMINI_API_KEY);


    private ObservableCollection<ChatItem> _chatItems;
    public ObservableCollection<ChatItem> ChatItems
    {
        get { return _chatItems; }
        set
        {
            _chatItems = value;
            OnPropertyChanged(nameof(ChatItems));
        }
    }
    private ObservableCollection<Message> _messages;
    public ObservableCollection<Message> Messages
    {
        get
        {
            return _messages;
        }
        set
        {
            _messages = value;
            OnPropertyChanged(nameof(Messages));
        }
    }

    public User currentUser
    {
        get; set;
    }
    public int userID = 1;
    public int targetUserID = 2;

    public ChatPageViewModel(IAuthenticationService authenticationService, IDao<User> userDao)
    {
        this.authenticationService = authenticationService;
        ChatItems = new ObservableCollection<ChatItem>();
        Messages = new ObservableCollection<Message>();
        _user = userDao;
        currentUser = this.authenticationService.GetCurrentUser();
        if (currentUser != null)
        {
            userID = currentUser.Id;
        }
        // Initialize chat items and messages asynchronously
        _ = InitializeChatAsync();
    }

    public bool ContainsDate(string input)
    { // Định nghĩa biểu thức chính quy cho ngày tháng
        string datePattern = @"\b(0?[1-9]|[12][0-9]|3[01])[-/.](0?[1-9]|1[0-2])[-/.](\d{4})\b";
        Regex regex = new Regex(datePattern);
        if (regex.IsMatch(input))
        {
            return true;
        }

        string[] keywords = { "ngày", "tháng", "năm", "date", "day", "month", "year" }; 
        foreach (var keyword in keywords) 
        { 
            if (input.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) 
            { 
                return true; 
            } 
        }
        return false;
    }
    public async Task InitializeChatAsync()
    {
        try
        {
            await ConnectToInitialServer();
            await ListConversations(userID.ToString("D6"));
            if (isReload)
            {
                var newMessages = await getMessagesAsync(targetUserID);
                var dispatcherQueue = DispatcherQueue.GetForCurrentThread();
                if (dispatcherQueue != null)
                {
                    await dispatcherQueue.EnqueueAsync(() =>
                    {
                        Messages = newMessages;
                    });
                }
                else
                {
                    Messages = newMessages;
                }
            }
            isReload = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Initialization error: {ex.Message}");
        }
    }

    private async Task ConnectToInitialServer()
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
                isConnectedToServer = false;
                isErrorOccurred = true;
                throw new Exception("Failed to receive a valid port from the server.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in ConnectToInitialServer: {ex.Message}");
            isConnectedToServer = false;
            throw;
        }
    }

    private async Task ConnectToDynamicPort()
    {
        try
        {
            client.Close();
            client = new TcpClient();
            await client.ConnectAsync(ServerAddress, dynamicPort);
            stream = client.GetStream();
            isConnectedToServer = true;
            isErrorOccurred = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in ConnectToDynamicPort: {ex.Message}");
            isConnectedToServer = false;
            isErrorOccurred = true;
            throw;
        }
    }

    private async Task Exit()
    {
        try
        {
            var message = "EXIT|EOM|";
            await SendToServer(message);
        }
        finally
        {
            client.Close();
            stream.Close();
        }
    }

    public string ExtractMessage(string message)
    {
        int firstColonIndex = message.IndexOf(':');
        if (firstColonIndex != -1)
        {
            // Extract the text after the first colon and trim any whitespace
            string textOnly = message.Substring(firstColonIndex + 1).Trim();
            return textOnly;
        }
        return message; // Return the original message if no colon is found
    }


    public async Task ListConversations(string userId)
    {
        await ConnectToInitialServer();
        var message = $"LIST {userId}|EOM|";
        
        var response = await SendToServer(message);

        try
        {
            var conversations = JsonSerializer.Deserialize<List<Conversation>>(response);
            var updatedChatItems = new List<ChatItem>(ChatItems);

            foreach (var conversation in conversations)
            {
                var id = int.Parse(conversation.OtherUserId);
                var user = await _user.GetByIdAsync(id);
                var userName = conversation.OtherUserId.ToString();
                if (user != null)
                {
                    userName = user.firstName + " " + user.lastName;
                    if (userName == " " || userName == null)
                    {
                        userName = user.Email;
                    }
                }
                var tmp = new ChatItem
                {
                    Id = int.Parse(conversation.OtherUserId),
                    personName = userName,
                    lastMessage = ExtractMessage(conversation.LastMessage),
                };

                var existingItem = updatedChatItems.FirstOrDefault(item => item.Id == tmp.Id);

                if (existingItem != null)
                {
                    if (existingItem.lastMessage != tmp.lastMessage)
                    {
                        // Update last message and move the item to the top
                        updatedChatItems.Remove(existingItem);
                        updatedChatItems.Insert(0, tmp);
                    }
                }
                else
                {
                    // Add new conversation to the top
                    updatedChatItems.Insert(0, tmp);
                }
            }
            var dispatcherQueue = DispatcherQueue.GetForCurrentThread();
            if (dispatcherQueue != null)
            {
                await dispatcherQueue.EnqueueAsync(() => ChatItems = new ObservableCollection<ChatItem>(updatedChatItems));
            }
            else
            {
                ChatItems = new ObservableCollection<ChatItem>(updatedChatItems);
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON error: {ex.Message}");
        }
        await Exit();
    }



    public async Task SendMessage(int targetUserId, string messageContent)
    {
        await ConnectToInitialServer();
        var message = $"SEND {userID.ToString("D6")} {targetUserId.ToString("D6")} {messageContent}|EOM|";
        await SendToServer(message);
        await Exit();
    }

    public async Task ReadMessages(int targetUserId)
    {
        await ConnectToInitialServer();
        var message = $"RECV {userID.ToString("D6")} {targetUserId.ToString("D6")}|EOM|";

        var response = await SendToServer(message);

        try
        {
            var messages = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(response);
            foreach (var msg in messages)
            {
                Message tmp = new Message
                {
                    Text = msg["message"],
                    isMine = msg["user"] == userID.ToString("D6"),
                    haveDate = ContainsDate(msg["message"]),
                };
                Messages.Add(tmp);
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Failed to deserialize response: {ex.Message}");
        }
        await Exit();
    }

    private async Task<string> SendToServer(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        await stream.WriteAsync(data, 0, data.Length);

        data = new byte[1024];
        int bytes = await stream.ReadAsync(data, 0, data.Length);
        return Encoding.UTF8.GetString(data, 0, bytes);
    }

    private async Task<ObservableCollection<ChatItem>> getChatItemsAsync()
    {
        ChatItems = new ObservableCollection<ChatItem>();
        await ListConversations(userID.ToString("D6"));
        return ChatItems;
    }

    public async Task<ObservableCollection<Message>> getMessagesAsync(int targetUserId)
    {
        Messages = new ObservableCollection<Message>();
        await ReadMessages(targetUserId);
        return Messages;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
