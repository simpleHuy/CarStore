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

namespace CarStore.ViewModels;
public partial class CarDetailViewModel : ObservableObject, INotifyPropertyChanged
{

    //private FullObservableCollection<Car>? _competitorModels;

    // Car will be binded
    private Car? _selectedCar;
    public FullObservableCollection<Car>? Cars
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

    // get all competitor Cars
    public ObservableCollection<Car>? CompetitorCars
    {
        get; set;
    }
    //private void LoadCompetitorCars()
    //{
    //    var delta = 0.2;
    //    var minPrice = SelectedCar.Price * (1.0 - delta);
    //    var maxPrice = SelectedCar.Price * (1.0 + delta);
    //    CompetitorCars = new ObservableCollection<Car>();
    //    foreach (var car in Cars)
    //    {
    //        if((car.Price > minPrice || /*&&*/ car.Price < maxPrice))// && car.CarId != SelectedCar.CarId)
    //        {
    //            CompetitorCars.Add(car);
    //        }
    //    }
    //}

    private void GetTopCompetitorCars()
    {
        var delta = 0.2;
        var minPrice = SelectedCar.Price * (1.0 - delta);
        var maxPrice = SelectedCar.Price * (1.0 + delta);
        CompetitorCars = new ObservableCollection<Car>();
        foreach (var car in Cars)
        {
            if (CompetitorCars.Count > 9)
                break;

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

    public CarDetailViewModel()
    {
        IDao dao = new MockDao();
        Cars = new FullObservableCollection<Car>(dao.getAllCars());
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
