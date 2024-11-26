using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;

namespace CarStore.ViewModels;

public class CompareViewModel
{
    private readonly IDao<CarDetail> _carDetail;
    private readonly IDao<Car> _car;

    public Car Car1
    {
        get; set;
    }

    public Car Car2
    {
        get; set;
    }

    public CompareViewModel(IDao<CarDetail> carDetail, IDao<Car> car)
    {
        _carDetail = carDetail;
        _car = car;
    }

}
