using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Models.Chat;

namespace CarStore.Contracts.Services;

public interface IChatService
{
    
    public ObservableCollection<ChatItem> GetChatItems();
    public ObservableCollection<Message> GetMessages(int userID);
    public void SendMessage(Message message);
}

