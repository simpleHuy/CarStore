using System.Collections.ObjectModel;
using System.ComponentModel;
using CarStore.Contracts.Services;
using CarStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarStore.ViewModels;

public class MainPageViewModel : ObservableObject, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public readonly INavigationService _navigateService;

    public ObservableCollection<Models.Car>? Items
    {
        get; set;
    }

    public ObservableCollection<Models.TypeOfCar>? Categories
    {
        get; set;
    }
    public IRelayCommand NavigateToLoginCommand { get;} // define functionc command
    public MainPageViewModel(INavigationService navigationService)
    {
        _navigateService = navigationService;

        NavigateToLoginCommand = new RelayCommand(()=> _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));

        Items = new ObservableCollection<Models.Car>
        {
            new(){
                Name = "Car1",
                Manufacturer = 1,
                EngineType = 1,
                TypeOfCar = 1,
                Price = 100000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Trắng ngọc trai", Code = "White" }, new() { Name = "Xanh đại dương", Code = "Blue" } },
                Images = "Car1",
                DefautlImageLocation = "../Assets/Cars/Car1/White/1.jpg"
            },
            new(){
                Name = "Car2",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đen huyền bí", Code = "Black" }, new() { Name = "Cam lè", Code = "Orange" } },
                Images = "Car2",
                DefautlImageLocation = "../Assets/Cars/Car2/Black/1.jpg"
            },
            new(){
                Name = "Car3",
                Manufacturer = 3,
                EngineType = 3,
                TypeOfCar = 3,
                Price = 300000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đỏ lửa", Code = "Red" }, new() { Name = "Xanh lá", Code = "Green" } },
                Images = "Car3",
                DefautlImageLocation = "../Assets/Cars/Car3/Orange/1.jpg"
            },
            new(){
                Name = "Car4",
                Manufacturer = 2,
                EngineType = 4,
                TypeOfCar = 4,
                Price = 400000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Vàng nắng", Code = "Yellow" }, new() { Name = "Tím than", Code = "Purple" } },
                Images = "Car4",
                DefautlImageLocation = "../Assets/Cars/Car4/Blue/1.jpg"
            },
            new(){
                Name = "Car1",
                Manufacturer = 1,
                EngineType = 1,
                TypeOfCar = 1,
                Price = 100000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Trắng ngọc trai", Code = "White" }, new() { Name = "Xanh đại dương", Code = "Blue" } },
                Images = "Car1",
                DefautlImageLocation = "../Assets/Cars/Car1/White/1.jpg"
            },
            new(){
                Name = "Car2",
                Manufacturer = 2,
                EngineType = 2,
                TypeOfCar = 2,
                Price = 200000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đen huyền bí", Code = "Black" }, new() { Name = "Cam lè", Code = "Orange" } },
                Images = "Car2",
                DefautlImageLocation = "../Assets/Cars/Car2/Black/1.jpg"
            },
            new(){
                Name = "Car3",
                Manufacturer = 3,
                EngineType = 3,
                TypeOfCar = 3,
                Price = 300000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Đỏ lửa", Code = "Red" }, new() { Name = "Xanh lá", Code = "Green" } },
                Images = "Car3",
                DefautlImageLocation = "../Assets/Cars/Car3/Orange/1.jpg"
            },
            new(){
                Name = "Car4",
                Manufacturer = 2,
                EngineType = 4,
                TypeOfCar = 4,
                Price = 400000000,
                UsageStatus = "New",
                Description = "Description",
                Variant = new List<Models.Color> { new() { Name = "Vàng nắng", Code = "Yellow" }, new() { Name = "Tím than", Code = "Purple" } },
                Images = "Car4",
                DefautlImageLocation = "../Assets/Cars/Car4/Blue/1.jpg"
            },

        };
        Categories = new ObservableCollection<TypeOfCar> {
            new() { Name = "SUV", ImageLocation = "../Assets/CategoryBackground/Car1.jpg" },
            new() { Name = "Xe điện", ImageLocation = "../Assets/CategoryBackground/Car2.jpg" },
            new() { Name = "Xe bán tải", ImageLocation = "../Assets/CategoryBackground/Car3.jpg" },
            new() { Name = "Xe mui trần", ImageLocation = "../Assets/CategoryBackground/Car4.jpg" },
            // Add more categories as needed
        };

    }


}

