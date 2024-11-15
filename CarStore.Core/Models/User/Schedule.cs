using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class Schedule
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public int MerchantId { get; set; }

    // Navgiation Properties
    public Car Car { get; set; }
    //public User Customer { get; set; }
    //public User Merchant { get; set; }
}
