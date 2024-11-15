using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;

public class Manufacturer
{
    public int Id
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }

    public ICollection<Car> cars { get; set; }
}
