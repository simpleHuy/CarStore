using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;

namespace CarStore.Models;

public class PriceOfCar : IFilterItem, INotifyPropertyChanged
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
    public string Type => "PriceOfCar";
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
