using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models.Chat;
public class ChatItem
{
    public int Id { get; set; }
    public string personName
    {
        get; set;
    }

    public string lastMessage
    {
        get; set;
    }
}
