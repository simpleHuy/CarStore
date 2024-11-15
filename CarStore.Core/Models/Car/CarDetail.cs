using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;

// it use in compare Cars
public class CarDetail
{
    [Key] public int CarId { get; set; }
    public int NumberSeat { get; set; }
    public double TimeGet100 { get; set; } //second
    public int MaxDistance { get; set; } //km
    public int Year { get; set; }
    
    //Navigation properties
    public Car Car { get; set; }
}
