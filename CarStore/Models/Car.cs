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
    public int IdSeats
    {
        get; set;
    }

    public int? PriceOfCarId
    {
        get; set;
    }

    public List<Color>? Variant
    {
        get; set;
    }

    public string? Images
    {
        get; set;
    }

    public string? Thumbnail
    {
        get
        {
            //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefautlImageLocation);
            //var directories = Directory.GetDirectories(path);
            //return directories[0] + "\\1.jpg";
            return DefautlImageLocation;
        }
    }

    public string? DefautlImageLocation
    {
        get; set;
    }

    public string DefaultColor
    {
        get
        {
            return Variant[0].Code;
        }
    }

    public float getOldPrice()
    {
        return (float)(Price /0.8);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
