using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
// showroom is a user with a list of cars
public class Showroom
{
    public int Id
    {
        get; set;
    }
    public int UserId
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public string Img { get; set; }
    public string Hotline
    {
        get; set;
    }
    public string Email
    {
        get; set;
    }

    public bool IsReputation
    {
        get; set;
    }

    public string Facebook
    {
        get; set;
    }

    public string Home
    {
        get; set;
    }

    public IList<Address> Address
    {
        get; set;
    }

    public User User
    {
        get; set;
    }
}
