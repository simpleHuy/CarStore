using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.ViewModels;
public class AddItemPageViewModel: ObservableObject
{
    private readonly IDao<Manufacturer> _manufacture;
    private readonly IDao<EngineType> _engineType;
    private readonly IDao<TypeOfCar> _typeOfCar;
    private readonly IDao<Variant> _variant;

    public List<Variant> Colors
    {
        get; set;
    }
    public ObservableCollection<VariantOfCar> Variants { get; set; } = new ObservableCollection<VariantOfCar>();
    public List<Manufacturer> Manufacturers { get; set; }
    public List<EngineType> EngineTypes {get; set;}
    public List<TypeOfCar> TypeOfCars {get; set;}
    public AddItemPageViewModel(IDao<Manufacturer> manufacture, IDao<EngineType> engineType, IDao<TypeOfCar> typeOfCar, IDao<Variant> variant)
    {

        _manufacture = manufacture;
        _engineType = engineType;
        _typeOfCar = typeOfCar;
        _variant = variant;
        Task.Run(async () =>
        {
            Manufacturers = await _manufacture.GetAllAsync();
            EngineTypes = await _engineType.GetAllAsync();
            TypeOfCars = await _typeOfCar.GetAllAsync();
            Colors = await _variant.GetAllAsync();
        }).Wait();
    }
}
