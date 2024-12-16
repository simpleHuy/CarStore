using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class Wishlist
{
    public int Id
    {
        get; set;
    }

    public int UserId
    {
        get; set;
    }

    public int CarId
    {
        get; set;
    }

    public User User
    {
        get; set;
    }

    public Car Car
    {
        get; set;
    }
}
