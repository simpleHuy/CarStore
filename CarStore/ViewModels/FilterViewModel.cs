using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using CarStore.Helpers;
using CarStore.Models;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using CarStore.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;

namespace CarStore.ViewModels;
public partial class FilterViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly CarFilterService _carFilterService;
    private string _searchQuery;


    // Car will be binded
    private Car? _selectedCar;
    private FullObservableCollection<Car> _cars;
    public FullObservableCollection<Car> Cars
    {
        get => _cars;
        set
        {
            _cars = value;
            OnPropertyChanged(nameof(Cars));
            _carFilterService.AllCars = value;  // Update service when cars change
        }
    }

    public Car? SelectedCar
    {
        get => _selectedCar;
        set
        {
            _selectedCar = value;
            OnPropertyChanged(nameof(SelectedCar));
            LoadPictureOfCar();
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

        if (SelectedCarColor == null)
        {
            //path += "\\" + SelectedCar.DefaultColor;
            //SelectedCarColor = SelectedCar.DefaultColor;
        }
        else
        {
            path += "\\" + SelectedCarColor;
        }

        if (Directory.Exists(path))
        {
            // Get all jpg files in the directory
            var imageFiles = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                                      .Where(file => Regex.IsMatch(file, @"\.(jpg|jpeg|png|gif|bmp|tiff)$", RegexOptions.IgnoreCase))
                                      .ToArray();

            // Convert file paths to proper URI format for WinUI
            var imageUris = imageFiles.Select((file, index) =>
                new Uri($"ms-appx:///../{file.Substring(file.IndexOf("Assets"))}").ToString());


            SelectedCarPictures = new ObservableCollection<string>(imageUris);
        }
        else
        {
            SelectedCarPictures = new ObservableCollection<string>();
        }
    }

    // get all filtered Cars
    public FullObservableCollection<Car> FilteredCars
    {
        get => _carFilterService.FilteredCars;
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
    // declare Manufacturer
    
    public FullObservableCollection<Manufacturer>? Manufacturers
    {
        get; set;
    }

    // declare EngineType
   
    public FullObservableCollection<EngineType>? EngineTypes
    {
        get; set;
    }

    public FullObservableCollection<PriceOfCar>? PriceCar
    {
        get; set;
    }

    // declare Number of Seats
    public FullObservableCollection<NumberSeat>? SeatOfCar
    {
        get; set;
    }

    // declare Type of Car
    public TypeOfCar? MainTypeCar
    {
        get; set;
    }
    public FullObservableCollection<TypeOfCar>? TypeCars
    {
        get; set;
    }


    private ObservableCollection<SelectedFilter> _selectedFilters;
    public ObservableCollection<SelectedFilter> SelectedFilters
    {
        get => _selectedFilters;
        set
        {
            _selectedFilters = value;
            OnPropertyChanged(nameof(SelectedFilters));
            _carFilterService.SelectedFilters = value;
        }
    }

    public FilterViewModel()
    {
        _carDao = App.GetService<IDao<Car>>();
        _manufacturerDao = App.GetService<IDao<Manufacturer>>();
        _engineTypeDao = App.GetService<IDao<EngineType>>();
        _priceOfCarDao = App.GetService<IDao<PriceOfCar>>();
        _typeOfCarDao = App.GetService<IDao<TypeOfCar>>();
        _numberOfSeatsDao = App.GetService<IDao<NumberSeat>>();
        _carRepository = App.GetService<ICarRepository>();
        _carFilterService = new CarFilterService();
        _carFilterService.PropertyChanged += OnCarFilterServicePropertyChanged;
        Task.Run(async () => await LoadInitialDataAsync()).Wait();
    }

    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            OnPropertyChanged(nameof(SearchQuery));
            _carFilterService.SearchQuery = value;
            //FilterCarsByQuery(value);
        }
    }
    private void OnCarFilterServicePropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_carFilterService.FilteredCars))
        {
            // Notify the ViewModel's FilteredCars property to update
            OnPropertyChanged(nameof(FilteredCars));
        }
    }
    private readonly IDao<Car> _carDao;
    private readonly IDao<Manufacturer> _manufacturerDao;
    private readonly IDao<EngineType> _engineTypeDao;
    private readonly IDao<PriceOfCar> _priceOfCarDao;
    private readonly IDao<TypeOfCar> _typeOfCarDao;
    private readonly IDao<NumberSeat> _numberOfSeatsDao;

    private readonly ICarRepository _carRepository;

    private async Task LoadInitialDataAsync()
    {
        var cars = await _carDao.GetAllAsync();
        var manufactures = await _manufacturerDao.GetAllAsync();
        var engineTypes = await _engineTypeDao.GetAllAsync();
        var priceOfCars = await _priceOfCarDao.GetAllAsync();
        var typeOfCars = await _typeOfCarDao.GetAllAsync();
        var numberOfSeats = await _numberOfSeatsDao.GetAllAsync();
        Cars = new FullObservableCollection<Car>(cars);
        Manufacturers = new FullObservableCollection<Manufacturer>(manufactures);
        EngineTypes = new FullObservableCollection<EngineType>(engineTypes);
        PriceCar = new FullObservableCollection<PriceOfCar>(priceOfCars);
        TypeCars = new FullObservableCollection<TypeOfCar>(typeOfCars);
        SeatOfCar = new FullObservableCollection<NumberSeat>(numberOfSeats);
        SelectedFilters = new ObservableCollection<SelectedFilter>();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }



}


