using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class RegisterDetail
{
    public int Id
    {
        get; set;
    }
    public int UserId
    {
        get; set;
    }
    public string Content
    {
        get; set;
    }
    public DateTime CreatedDate
    {
        get; set;
    }

    public User User
    {
        get; set;
    }
}
