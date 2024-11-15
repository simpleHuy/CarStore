using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Core.Models;
public class Car : INotifyPropertyChanged
{
    public int CarId
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    //public int? Manufacturer
    //{
    //    get; set;
    //}
    //public int? EngineType
    //{
    //    get; set;
    //}
    //public int? TypeOfCar
    //{
    //    get; set;
    //}
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

    //public List<Variant>? Variant
    //{
    //    get; set;
    //}

    public string Images
    {
        get; set;
    }

    public string DefautlImageLocation
    {
        get; set;
    }

    //public string DefaultColor
    //{
    //    get
    //    {
    //        return Variant[0].Code;
    //    }
    //}


    public IList<VariantOfCar> VariantOfCars { get; set; }
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }

    public int EngineTypeId
    {
        get; set;
    }
    public EngineType EngineType
    {
        get; set;
    }

    public int TypeOfCarId
    {
        get; set;
    }
    public TypeOfCar TypeOfCar
    {
        get; set;
    }

    public CarDetail carDetail { get; set; }
    public ICollection<Schedule> Schedules { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}
