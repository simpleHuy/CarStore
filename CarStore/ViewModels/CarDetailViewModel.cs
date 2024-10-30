using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CarStore.Helpers;
using CarStore.Models;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.ViewModels;
public partial class CarDetailViewModel : INotifyPropertyChanged
{

    private Car? _selectedCar;
    //private FullObservableCollection<Car>? _competitorModels;


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
            LoadCompetitorCars();
        }
    }

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
    private void LoadPictureOfCar()
    {
        if (SelectedCar == null) return;

        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SelectedCar.Images);

        if (Directory.Exists(path))
        {
            // Get all jpg files in the directory
            var imageFiles = Directory.GetFiles(path, "*.jpg", SearchOption.TopDirectoryOnly);

            // Convert file paths to proper URI format for WinUI
            var imageUris = imageFiles.Select((file, index) =>
                new Uri($"ms-appx:///{SelectedCar.Images}/{index + 1}.jpg").ToString());

            SelectedCarPictures = new ObservableCollection<string>(imageUris);
        }
        else
        {
            SelectedCarPictures = new ObservableCollection<string>();
        }
    }

    public ObservableCollection<Car>? CompetitorCars
    {
        get; set;
    }
    private void LoadCompetitorCars()
    {
        var delta = 0.2;
        var minPrice = SelectedCar.Price * (1.0 - delta);
        var maxPrice = SelectedCar.Price * (1.0 + delta);
        CompetitorCars = new ObservableCollection<Car>();
        foreach (var car in Cars)
        {
            if (CompetitorCars.Count() > 8)
                break;

            if((car.Price > minPrice || /*&&*/ car.Price < maxPrice))// && car.CarId != SelectedCar.CarId)
            {
                CompetitorCars.Add(car);
            }
        }
    }

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
