using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class Car : INotifyPropertyChanged
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CarId
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }

    public long? Price
    {
        get; set;
    }
    public string UsageStatus
    {
        get; set;
    }
    public string Description
    {
        get; set;
    }


    public string Images
    {
        get; set;
    }

    private string _defautlImageLocation;
    public string DefautlImageLocation
    {
        get => _defautlImageLocation;
        set
        {
            if (_defautlImageLocation != value)
            {
                _defautlImageLocation = value;
                OnPropertyChanged();
            }
        }
    }

    // Navigation properties
    public int ManufacturerId
    {
        get; set;
    }
    public int EngineTypeId
    {
        get; set;
    }
    public int TypeOfCarId
    {
        get; set;
    }
    public int PriceOfCarId
    {
        get; set;
    }
    public Manufacturer Manufacturer { get; set; }
    public EngineType EngineType { get; set; }
    public TypeOfCar TypeOfCar { get; set; }
    public IList<VariantOfCar> VariantOfCars { get; set; }
    public CarDetail carDetail { get; set; }
    public PriceOfCar PriceOfCar { get; set; }
    public IList<Schedule> Schedules
    {
        get; set;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
