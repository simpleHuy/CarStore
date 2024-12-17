using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get;
        set;
    }
    public string Name
    {
        get; set;
    }
    public string Email
    {
        get; set;
    }
    public string Telephone
    {
        get; set;
    }
    public string AccountType
    {
        get; set;
    }

    public string PasswordHash
    {
        get; set;
    }
    public string Salt
    {
        get; set;
    }
    public string Username
    {
        get; set;
    }
    public string firstName
    {
        get; set;
    }
    public string lastName
    {
        get; set;
    }

    public bool IsShowroom
    {
        get; set;
    }

    public Showroom Showroom
    {
        get; set;
    }
    public ICollection<Schedule> CustommerSchedules { get; set; }
    public ICollection<Schedule> MerchantSchedules { get; set; }
    public ICollection<Wishlist> Wishlists
    {
        get; set;
    }
    public List<Car> Cars
    {
        get; set;
    }
}
