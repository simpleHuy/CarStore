using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ObservableCollection<string>? SelectedCarPictures
    {
        get; set;
    }
    private void LoadPictureOfCar()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SelectedCar.Picture);
        if (SelectedCar != null && Directory.Exists(path))
        {
            // Lấy tất cả các file ảnh (jpg, png, jpeg) trong thư mục
            var imageFiles = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                                      .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".jpeg"));

            // Gán danh sách ảnh vào SelectedCarPictures để bind với FlipView
            SelectedCarPictures = new ObservableCollection<string>(imageFiles);
        }
        else
        {
            // Nếu không tìm thấy thư mục, hoặc không có ảnh, thì clear danh sách ảnh
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

            if((car.Price > minPrice || car.Price < maxPrice))// && car.CarId != SelectedCar.CarId)
            {
                CompetitorCars.Add(car);
            }
        }
    }


    public CarDetailViewModel()
    {
        IDao dao = new MockDao();
        Cars = new FullObservableCollection<Car>(dao.getAllCars());
    }


    public event PropertyChangedEventHandler? PropertyChanged;
}
