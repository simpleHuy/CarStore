using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class Variant : INotifyPropertyChanged
{
    public int Id
    {
        get; set;
    }

    public string Code
    {
        get; set;
    }

    //Navigation Property
    public IList<VariantOfCar> VariantOfCars { get; set; }

    public override string ToString()
    {
        return Code;
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
