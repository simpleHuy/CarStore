using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models;
using CarStore.Core.Models.Chat;
using CarStore.Models.AI;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.ViewModels
{
    public class ChatPageViewModel: ObservableObject, INotifyPropertyChanged
    {
        private static string GEMINI_API_KEY = "GEMINI_API_KEY";
        public GeminiChatbot gemini = new(GEMINI_API_KEY);
        public MainPageViewModel mainPageViewModel {get; set;}
        public ObservableCollection<ChatItem> ChatItems { get; set; }
        public ObservableCollection<Message> Messages { get; set; }
        public List<ChatHistory> history = new()
        {
            new ChatHistory
            {
                role = "user",
                parts = new List<string> { "Hello, how are you today" }
            },
            new ChatHistory
            {
                role = "model",
                parts = new List<string> { "I'm doing well, thank you for asking! How are you today?\n" }
            }
        };
        public User currentUser {get; set;}
        public int userID = 0;
        public ChatPageViewModel()
        {
            mainPageViewModel = App.GetService<MainPageViewModel>();
            currentUser = mainPageViewModel.CurrentUser;
            userID = currentUser.Id;
            ChatItems = new ObservableCollection<ChatItem>(
                new List<ChatItem>
                {
                    new ChatItem
                    {
                        Id = 1,
                        personName = "John",
                        lastMessage = "Hello"
                    },
                    new ChatItem
                    {
                        Id = 2,
                        personName = "Alice",
                        lastMessage = "Hi"
                    },
                    new ChatItem
                    {
                        Id = 3,
                        personName = "Bob",
                        lastMessage = "Hey"
                    }
                }
            );
            Messages = new ObservableCollection<Message>(
                new List<Message>
                {
                    new Message
                    {
                        Text = "Hello, long time no see!",
                        isMine = true,
                    },
                    new Message
                    {
                        Text = "How are you?",
                        isMine = true,
                    },
                    new Message
                    {
                        Text = "Haah, long time no seeee",
                        isMine = false,
                    },
                    new Message
                    {
                        Text = "I'm fine, thank you",
                        isMine = false,
                    },
                    new Message
                    {
                        Text = "Do you want to go somewhere this weekend?",
                        isMine = false,
                    },
                    new Message
                    {
                        Text = "Sure, where do you want to go?",
                        isMine = true,
                    },
                    new Message
                    {
                        Text = "I'm thinking about going to the beach",
                        isMine = false,
                    },

                }
            );
        }
    }
}
