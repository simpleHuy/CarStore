using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class VariantOfCar
{
    public int CarId { get; set; }
    public int VariantId { get; set; }
    public string Name { get; set; }
    
    //Navigation Properties
    public Car Car { get; set; }
    public Variant Variant { get; set; }
}
