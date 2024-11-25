using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Core.Contracts.Services;

namespace CarStore.Core.Models;

public class EngineType : IFilterItem, INotifyPropertyChanged
{
    public int Id
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }

    // Navigation Property
    public ICollection<Car> cars
    {
        get; set;
    }

    public event PropertyChangedEventHandler PropertyChanged;

}
