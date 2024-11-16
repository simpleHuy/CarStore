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
using CarStore.Services.DataAccess;
using CarStore.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.ViewModels;
public partial class FilterViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly CarFilterService _carFilterService;
    

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

    //public int Max_Item
    //{
    //    get; set;
    //}

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
            path += "\\" + SelectedCar.DefaultColor;
            SelectedCarColor = SelectedCar.DefaultColor;
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

    // get all competitor Cars
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
    public FullObservableCollection<NumberOfSeats>? SeatOfCar
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
        _carFilterService = new CarFilterService();
        _carFilterService.PropertyChanged += OnCarFilterServicePropertyChanged;
        InitializeData();
    }

    private void OnCarFilterServicePropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_carFilterService.FilteredCars))
        {
            // Notify the ViewModel's FilteredCars property to update
            OnPropertyChanged(nameof(FilteredCars));
        }
    }

    private void InitializeData()
    {
        IDao dao = new MockDao();
        Cars = new FullObservableCollection<Car>(dao.getAllCars());
        Manufacturers = new FullObservableCollection<Manufacturer>(dao.getAllManufacturers());
        EngineTypes = new FullObservableCollection<EngineType>(dao.GetEngineTypes());
        TypeCars = new FullObservableCollection<TypeOfCar>(dao.GetTypeOfCar());
        SeatOfCar = new FullObservableCollection<NumberOfSeats>(dao.getNumberOfSeats());
        SelectedFilters = new ObservableCollection<SelectedFilter>();
        //{
        //    new SelectedFilter { Type = "Manufacturer", Id = 1, Name = "Honda" },
        //    new SelectedFilter { Type = "EngineType", Id = 1, Name = "Xăng" }
        //};
        PriceCar = new FullObservableCollection<PriceOfCar>(dao.getPriceOfCars());

    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}


