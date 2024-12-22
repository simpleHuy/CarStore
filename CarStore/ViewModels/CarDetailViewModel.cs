using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CarStore.Helpers;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CarStore.Core.Models;
using CarStore.Core.Daos;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Contracts.Repository;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using CarStore.Contracts.Services;
using Supabase;

namespace CarStore.ViewModels;
public partial class CarDetailViewModel : ObservableObject, INotifyPropertyChanged
{

    // Car will be binded
    private Car? _selectedCar;
    public List<Car>? Cars
    {
        get; set;
    }
    public Car? SelectedCar
    {
        get => _selectedCar;
        set
        {
            _selectedCar = value;
            OnPropertyChanged(nameof(SelectedCar));
            LoadPictureOfCar();
            GetTopCompetitorCars();
            Task.Run(async () => Owner = await _userDao.GetByIdAsync(SelectedCar.OwnerId)).Wait();
            if(Owner.IsShowroom)
            {
                Task.Run(async () => Showroom = await _carRepository.GetShowroomByCarId(SelectedCar.CarId)).Wait();
            }
        }
    }

    // all images of Selected_car
    private ObservableCollection<string> _selectedCarPictures;
    public ObservableCollection<string>? SelectedCarPictures
    {
        get => _selectedCarPictures;
        set
        {
            _selectedCarPictures = value;
            OnPropertyChanged(nameof(SelectedCarPictures));
        }
    }

    private string _selectedCarColor;
    public string SelectedCarColor
    {
        get => _selectedCarColor;

        set
        {
            _selectedCarColor = value;
            OnPropertyChanged(nameof(_selectedCarColor));
            LoadPictureOfCar();
        }
    }


    // load all images of the car
    private void LoadPictureOfCar()
    {
        if (SelectedCar == null) return;

        var path = AppDomain.CurrentDomain.BaseDirectory;
        path += "Assets\\Cars\\" + SelectedCar.Images;
        path = path.Replace("\\bin\\x64\\Debug\\net7.0-windows10.0.19041.0\\AppX", "");

        if (SelectedCarColor == null)
        {
            List<VariantOfCar> variantOfCars = new List<VariantOfCar>();
            string variantsCode = "";
            Task.Run(async () => variantOfCars = await _carRepository.GetVariantsOfCar(SelectedCar.CarId)).Wait();
            Task.Run(async () => variantsCode = await _carRepository.GetVariantsCodeByName(variantOfCars[0].Name)).Wait();
            SelectedCar.VariantOfCars = variantOfCars;
            path += "\\" + variantsCode;
        }
        else
        {
            string variantsCode = "";
            Task.Run(async () => variantsCode = await _carRepository.GetVariantsCodeByName(SelectedCarColor)).Wait();
            path += "\\" + variantsCode;
        }


        if (!Directory.Exists(path))
        {
            var basePathIndex = path.IndexOf("Assets\\Cars");
            var downloadPath = path.Substring(0, basePathIndex + "Assets\\Cars".Length);
            downloadPath = downloadPath.Replace("\\bin\\x64\\Debug\\net7.0-windows10.0.19041.0\\AppX", "");
            downloadPath += "\\" + SelectedCar.Images;
            Task.Run(() => DownloadImage(downloadPath, SelectedCar.supabaseFolder)).Wait();
        }

        // Get all jpg files in the directory
        var imageFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

        // Convert file paths to proper URI format for WinUI
        //var imageUris = imageFiles.Select((file, index) =>
        //    new Uri($"ms-appx:///../{file.Substring(file.IndexOf("Assets"))}").ToString());

        SelectedCarPictures = new ObservableCollection<string>(imageFiles);
    }

    private async Task DownloadImage(string downloadPath, string folder)
    {
        try
        {
            var items = await GlobalVariable.Supabase.Storage.From(GlobalVariable.bucket).List(folder);
            foreach (var item in items)
            {
                var currentRemotePath = Path.Combine(folder, item.Name).Replace("\\", "/");
                var currentLocalPath = Path.Combine(downloadPath, item.Name);
                if (item.Id == null) // This is a folder
                {
                    // Create local subfolder
                    Directory.CreateDirectory(currentLocalPath);
                    // Recursively download contents of this subfolder
                    await DownloadImage(currentLocalPath, currentRemotePath);
                }
                else
                {
                    var img = await GlobalVariable.Supabase.Storage.From(GlobalVariable.bucket).DownloadPublicFile(currentRemotePath);
                    await File.WriteAllBytesAsync(currentLocalPath, img);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    // get all competitor Cars
    public List<Car>? CompetitorCars
    {
        get; set;
    }
    private void GetTopCompetitorCars()
    {
        var delta = 0.2;
        var minPrice = SelectedCar.Price * (1.0 - delta);
        var maxPrice = SelectedCar.Price * (1.0 + delta);
        CompetitorCars = new List<Car>();
        foreach (var car in Cars)
        {
            if (/*(car.Price >= minPrice && car.Price <= maxPrice) && car.CarId != SelectedCar.CarId*/ true)
            {
                CompetitorCars.Add(car);
            }
        }
    }

    // get selected image index to display on grid view
    private int _selectedImageIndex;
    public int SelectedImageIndex
    {
        get => _selectedImageIndex;
        set
        {
            _selectedImageIndex = value;
            OnPropertyChanged(nameof(SelectedImageIndex));
        }
    }

    private readonly IDao<Car> _carDao;
    private readonly ICarRepository _carRepository;
    private readonly IAuthenticationService authentication;
    private readonly IUserRepository userRepository;
    private readonly IDao<User> _userDao;

    public bool IsLogin
    {
        get
        {
            var user = authentication.GetCurrentUser();
            return user != null;
        }
    }
    public Showroom Showroom
    {
        get; set;
    }
    public User Owner
    {
        get; set;
    }

    public CarDetailViewModel(IDao<Car> car, ICarRepository carRepository, IAuthenticationService authentication, 
        IUserRepository userRepository, IDao<User> userDao)
    {
        _userDao = userDao;
        this.userRepository = userRepository;
        _carDao = car;
        _carRepository = carRepository;
        Task.Run(async () => 
        { 
            await LoadInitialDataAsync();
        }).Wait();
        this.authentication = authentication;
    }

    private async Task LoadInitialDataAsync()
    {
        var cars = await _carDao.GetAllAsync();
        Cars = new List<Car>(cars);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public IRelayCommand NavigateToScheduleCommand
    {
        get;
    }

    public void AddToWishlist()
    {
        Task.Run(async () =>
        {
            var user = authentication.GetCurrentUser();
            if (user != null)
            {
                await userRepository.AddCarToWishlist(user.Id, SelectedCar!.CarId);
            }
        }).Wait();
    }
}
