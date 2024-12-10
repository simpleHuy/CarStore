using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using CarStore.Contracts.Services;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Helpers;
using CarStore.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CarStore.Views;
public sealed partial class Compare : UserControl, INotifyPropertyChanged
{
    public readonly CarDetailViewModel ViewModel;
    private readonly IDao<Car> _carDao;
    private readonly INavigationService _navigationService;

    public Car Car1 { get; set; }

    private Car _car;
    public Car Car
    {
        get => _car;
        set
        {
            if (_car != value)
            {
                _car = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Car)));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public List<Car> Cars
    {
        get; set;
    } = new List<Car>();
    public List<Car> CompetitorCars
    {
        get; set;
    }
    public Compare(CarDetailViewModel VM)
    {
        _carDao = App.GetService<IDao<Car>>();
        _navigationService = App.GetService<INavigationService>();
        ViewModel = VM;

        Task.Run(async() => Cars = await _carDao.GetAllAsync()).Wait();
        foreach (var car in Cars) 
        {
            car.DefautlImageLocation = "../" + car.DefautlImageLocation;
            if (car.CarId == ViewModel.SelectedCar.CarId)
            {
                Car1 = car;
            }
        }
        Cars.Remove(Car1);
        CompetitorCars = new List<Car>(Cars);
        this.InitializeComponent();
    }

    private void TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
        {
            // Filter cars by name or manufacturer
            var suitableItems = Cars
                .Where(car =>
                    car.Name.Contains(sender.Text, StringComparison.OrdinalIgnoreCase) ||
                    car.ManufacturerId.ToString().Contains(sender.Text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // If no match, display "No results found"
            if (suitableItems.Count == 0)
            {
                sender.ItemsSource = new[] { new { Name = "No results found", DefautlImageLocation = string.Empty } };
            }
            else
            {
                sender.ItemsSource = suitableItems;
            }
        }
    }

    private void QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {

    }

    private void CarChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        var car = args.SelectedItem as Car; // Get selected car
        if(car == null)
        {
            return;
        }
        Car = car;
        sender.Text = car.Name;
        NotEnough.IsOpen = true;
    }

    private void ChooseThisCar(object sender, ItemClickEventArgs e)
    {
        var car = e.ClickedItem as Car;
        if (car == null)
            return;
        
        Car = car;
        NotEnough.IsOpen = false;
    }

    private async void Accept_btn_click(object sender, RoutedEventArgs e)
    {
        if(Car == null)
        {
            NotEnough.Message = "Vui lòng chọn thêm 1 chiếc xe để so sánh!";
            NotEnough.IsOpen = true; // Hiển thị thông báo lỗi
            return;
        }

        if (this.Parent is ContentDialog dialog)
        {
            dialog.Hide();
        }
        var car1 = ViewModel.SelectedCar;
        var car2 = Car;
        car1.DefautlImageLocation = Regex.Replace(car1.DefautlImageLocation, @"^\.\./", "");
        car2.DefautlImageLocation = Regex.Replace(car2.DefautlImageLocation, @"^\.\./", "");
        _navigationService.NavigateTo(typeof(CompareViewModel).FullName!, new List<Car> { car1, car2 });
    }

    private void Cancel_btn_click(object sender, RoutedEventArgs e)
    {
        if (this.Parent is ContentDialog dialog)
        {
            dialog.Hide();
        }
    }
}
