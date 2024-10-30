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
    public int? Manufacturer
    {
        get; set;
    }
    public int? EngineType
    {
        get; set;
    }
    public int? TypeOfCar
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

    public string? Variant
    {
        get; set;
    }

    public string? Images
    {
        get; set;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
