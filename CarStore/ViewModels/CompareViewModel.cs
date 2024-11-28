using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarStore.ViewModels;

public class CompareViewModel : ObservableObject
{
    private readonly IDao<CarDetail> _carDetail;
    private readonly IDao<Car> _car;

    private List<Car> _cars;
    public List<Car> CarCompare
    {
        get
        {
            return _cars;
        }
        set
        {
            _cars = value;
            foreach (var car in _cars)
            {
                Task.Run(async () =>
                {
                    var carDetail = await _carDetail.GetByIdAsync(car.CarId);
                    if (carDetail != null)
                    {
                        car.carDetail = carDetail;
                    }
                }).Wait();
            }
        }
    }

    public CompareViewModel(IDao<CarDetail> carDetail, IDao<Car> car)
    {
        _carDetail = carDetail;
        _car = car;
    }

}
