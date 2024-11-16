using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;

namespace CarStore.Models;

public class NumberOfSeats : IFilterItem, INotifyPropertyChanged
{
    public int Id
    {
        get; set;
    }
    public string? Name
    {
        get; set;
    }

    public string Type => "NumberOfSeats";
    public string? ImageLocation
    {
        get; set;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
