using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using CarStore.ViewModels;
using CarStore.Core.Models.Chat;
using Microsoft.UI.Xaml.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;
using ABI.Windows.UI;
using Microsoft.UI;
using System.Collections.ObjectModel;
using Windows.Networking.NetworkOperators;
using CarStore.Models.AI;
using Microsoft.VisualBasic.ApplicationServices;
using CarStore.Core.Models;
using Windows.System;
using Windows.ApplicationModel.Chat;
using System.Threading;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChatPage : Page
    {   
        public ChatPageViewModel ViewModel { get; set; }
        private Timer Timer;
        public ChatPage()
        {
            this.InitializeComponent();
            ViewModel = App.GetService<ChatPageViewModel>();
            DataContext = ViewModel;
            GeminiInit();
            //Timer = new Timer(async _ => { await ViewModel.InitializeChatAsync(); }, null, 0, 5000);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

        if (e.Parameter is int targetUserId)
        {
            ViewModel.targetUserID = (int)e.Parameter;
            ChatInit(targetUserId);
        }
    }

        private async void ChatListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChatListView.SelectedItem is ChatItem chatItem)
            {
                ViewModel.targetUserID = chatItem.Id;
                _ = ViewModel.InitializeChatAsync();
                MessageField.Text = "";
                await Task.Delay(100); // Adjust delay as needed
                if (ViewModel.Messages.Count > 0) { 
                    MessagesListView.ScrollIntoView(ViewModel.Messages.Last()); 
                }
                NameOfCurrentMessage.Text = chatItem.personName;
                NameOfCurrentMessage.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

    private void GeminiButton_Click(object sender, RoutedEventArgs e)
    {
        GeminiInit();
    }

        private void GeminiInit()
        {
            NameOfCurrentMessage.Text = "Gemini";
            NameOfCurrentMessage.Foreground = App.Current.Resources["GeminiColor"] as LinearGradientBrush;
            ViewModel.Messages = new ObservableCollection<Message>(
                new List<Message>
                {
                    new() {
                        Text = "Xin chào, tôi là Gemini, tôi có thể giúp gì cho bạn?",
                        isMine = false,
                        haveDate = false,
                    },
                }
            );
        }

    private async void ChatInit(int userID)
    {
        var targetUser = await ViewModel._user.GetByIdAsync(userID);
        var targetName = targetUser.firstName +" "+ targetUser.lastName;
        if (targetName == null|| targetName == " ")
        {
            targetName = targetUser.Email;
        }
        NameOfCurrentMessage.Text = targetName;

            NameOfCurrentMessage.Foreground = App.Current.Resources["GeminiColor"] as LinearGradientBrush;
            var Text = "Xin chào, tôi muốn liên hệ!";
            ViewModel.targetUserID = userID;
            _ = ViewModel.InitializeChatAsync();
            MessageField.Text = Text;
            await Task.Delay(100); // Adjust delay as needed
            if (ViewModel.Messages.Count > 0)
            {
                MessagesListView.ScrollIntoView(ViewModel.Messages.Last());
            }
        }

    private async void SendMessageBtn_Click(object sender, RoutedEventArgs e)
    {
        SendMessageAsync();
    }

    private void Reload_Click(object sender, RoutedEventArgs e)
    {
        if (NameOfCurrentMessage.Text == "Gemini")
        {
            GeminiInit();
        }
        else
        {
            _ = ViewModel.InitializeChatAsync();
        }
    }

    private void MessageField_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == Windows.System.VirtualKey.Enter)
        {
            SendMessageAsync();
        }
    }

        private async void SendMessageAsync()
        {
            if (MessageField.Text == "")
            {
                return;
            }
            if (NameOfCurrentMessage.Text == "Gemini")
            {
                ViewModel.Messages.Add(new Message
                {
                    Text = MessageField.Text,
                    isMine = true,
                    haveDate = ViewModel.ContainsDate(MessageField.Text),
                });
                var promt = MessageField.Text;
                MessageField.Text = "";

            var History = new List<ChatHistory>();
            var response = await ViewModel.gemini.GenerateResponseAsync(promt, History);
            ViewModel.Messages.Add(new Message
            {
                Text = response,
                isMine = false,
                haveDate = ViewModel.ContainsDate(response),
            });
        }
        else
        {
            _ = ViewModel.SendMessage(ViewModel.targetUserID, MessageField.Text); //change this to target userID
            ViewModel.Messages.Add(new Message
            {
                Text = MessageField.Text,
                isMine = true,
                haveDate = ViewModel.ContainsDate(MessageField.Text),
            });
            MessageField.Text = "";
            _ = ViewModel.InitializeChatAsync();
        }
    }

    private async void DateRedirect_Click(object sender, RoutedEventArgs e)
    {
            await new ContentDialog()
            {
                XamlRoot = this.Content.XamlRoot,
                Title = "Tính năng chưa khả dụng",
                Content = "Tính năng đang trong giai đoạn hoàn thiện. Vui lòng đợi các bản cập nhật sau!",
                CloseButtonText = "OK",
            }.ShowAsync();
    }
}
