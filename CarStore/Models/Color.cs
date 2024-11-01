using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Models;
public class Color : INotifyPropertyChanged
{
    public int Id
    {
        get; set;
    }

    public string? Name
    {
        get; set;
    }

    public string? Code
    {
        get; set;
    }

    public override string ToString() {
        return Code;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
