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
    public Car Car { get; set; }
    public double TimeGet100
    {
        get; set;
    }

    public int MaxDistance { get; set; }
    public int Year { get; set; }
}
