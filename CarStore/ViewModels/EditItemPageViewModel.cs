using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI.System.Collections;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.ViewModels;

public class EditItemPageViewModel:ObservableObject,INotifyPropertyChanged
{
    private readonly IDao<Manufacturer> _manufacture;
    private readonly IDao<EngineType> _engineType;
    private readonly IDao<TypeOfCar> _typeOfCar;
    private readonly IDao<Variant> _variant;
    public ObservableCollection<VariantOfCar> Variants { get; set; } = new();

    public List<Variant> Colors
    {
        get; set;
    }
    public ObservableCollection<Manufacturer> Manufacturers
    {
        get; set;
    }
    public ObservableCollection<EngineType> EngineTypes
    {
        get; set;
    }
    public ObservableCollection<TypeOfCar> TypeOfCars
    {
        get; set;
    }
    public EditItemPageViewModel(IDao<Manufacturer> manufacture, IDao<EngineType> engineType, IDao<TypeOfCar> typeOfCar, IDao<Variant> variant)
    {
        //Manufacturers = new ObservableCollection<Manufacturer>(dao.getAllManufacturers());
        //EngineTypes = new ObservableCollection<EngineType>(dao.GetEngineTypes());
        //TypeOfCars = new ObservableCollection<TypeOfCar>(dao.GetTypeOfCar());
        _manufacture = manufacture;
        _engineType = engineType;
        _typeOfCar = typeOfCar;
        _variant = variant;
        Task.Run(async () =>
        {
            Manufacturers = new ObservableCollection<Manufacturer>(await _manufacture.GetAllAsync());
            EngineTypes = new ObservableCollection<EngineType>(await _engineType.GetAllAsync());
            TypeOfCars = new ObservableCollection<TypeOfCar>(await _typeOfCar.GetAllAsync());
            Colors = await _variant.GetAllAsync();
        }).Wait();
    }

}
