using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;

namespace CarStore.Core.Models;
public class NumberSeat: IFilterItem, INotifyPropertyChanged
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
    public ICollection<CarDetail> CarDetails
    {
        get; set;
    }

}
