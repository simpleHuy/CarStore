﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;

namespace CarStore.Core.Models;

public class TypeOfCar : IFilterItem, INotifyPropertyChanged
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public string ImageLocation
    {
        get; set;
    }

    //Navigation Property
    public ICollection<Car> cars
    {
        get; set;
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
