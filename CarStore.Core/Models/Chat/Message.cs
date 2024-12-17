using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models.Chat;
public class Message
{
    public string Text
    {
        get; set;
    }

    public bool isMine
    {
        get; set;
    }
}
