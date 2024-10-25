using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace CarStore.Models;
public class Car : INotifyPropertyChanged
{
    public int CarId
    {
        get; set;
    }
    public string? Name
    {
        get; set;
    }
    public string? Manufacturer
    {
        get; set;
    }
    public string? EngineType
    {
        get; set;
    }
    public string? TypeOfCar
    {
        get; set;
    }
    public long? Price
    {
        get; set;
    }
    public string? UsageStatus
    {
        get; set;
    }
    public string? Description
    {
        get; set;
    }

    public string? Picture
    {
        get; set;
    }

    public string? Avatar
    {
        get; set;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
