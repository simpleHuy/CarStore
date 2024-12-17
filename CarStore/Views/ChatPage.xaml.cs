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
        public ChatPage()
        {
            this.InitializeComponent();
            ViewModel = App.GetService<ChatPageViewModel>();
            GeminiInit();
        }

        private void ChatListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChatListView.SelectedItem is ChatItem chatItem)
            {
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
                    new Message
                    {
                        Text = "Gemini is here to help you!",
                        isMine = false,
                    },
                }
            );
        }

        private async void SendMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Messages.Add(new Message
            {
                Text = MessageField.Text,
                isMine = true,
            });
            MessageField.Text = "";
            var promt = MessageField.Text;
            var response = await ViewModel.gemini.GenerateResponseAsync(promt,ViewModel.history);
            ViewModel.Messages.Add(new Message
            {
                Text = response,
                isMine = false,
            });
        }
    }
}
