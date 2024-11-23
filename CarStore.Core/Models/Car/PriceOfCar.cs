using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;

public class PriceOfCar : INotifyPropertyChanged
{
    public int Id
    {
        get; set;
    }
    public string? Name
    {
        get; set;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ICollection<Car> Cars
    {
        get; set;
    }
}
