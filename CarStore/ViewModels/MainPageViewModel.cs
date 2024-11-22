using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CarStore.Contracts.Services;
using CarStore.Contracts.ViewModels;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Daos;
using CarStore.Core.Models;
using CarStore.Core.Repository;
using CarStore.Helpers;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarStore.ViewModels;

public class MainPageViewModel : ObservableObject, INotifyPropertyChanged
{
    private readonly IDao<Car> _car;
    private readonly IDao<TypeOfCar> _typeOfCar;
    public readonly ICarRepository _carRepository;
    public readonly INavigationService _navigateService;
    public readonly IAuthenticationService _authenticationService;
    private User? _currentUser;
    public User? CurrentUser
    {
        get => _currentUser;
        set
        {
            if (_currentUser != value)
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
    }

    private bool _isLogin;
    public bool IsLogin
    {
        get => _isLogin;
        set
        {
            if (_isLogin != value)
            {
                _isLogin = value;
                OnPropertyChanged(nameof(IsLogin));
            }
        }
    }

    private FullObservableCollection<Car>? _items = new();
    public FullObservableCollection<Car>? Items
    {
        get => _items;
        set
        {
            _items = value;
            OnPropertyChanged();
        }
    }

    private FullObservableCollection<TypeOfCar>? _categories = new();
    public FullObservableCollection<TypeOfCar>? Categories
    {
        get => _categories;
        set
        {
            _categories = value;
            OnPropertyChanged();
        }
    }

    private FullObservableCollection<Car>? _PopularCars = new();
    public FullObservableCollection<Car>? PopularCars
    {
        get => _PopularCars;
        set
        {
            _PopularCars = value;
            OnPropertyChanged();
        }
    }

    private FullObservableCollection<Car>? _suggestCars = new();
    public FullObservableCollection<Car>? SuggestCars 
    {
        get => _suggestCars;
        set
        {
            _suggestCars = value;
            OnPropertyChanged();
        }
    }

    public IRelayCommand NavigateToLoginCommand
    {
        get;
    }
    public IRelayCommand NavigateToSignupCommand
    {
        get;
    }
    //public IRelayCommand LogoutCommand
    //{
    //    get;
    //}
    public MainPageViewModel(INavigationService navigationService, IAuthenticationService authService, IDao<Car> car, IDao<TypeOfCar> typeOfCar, ICarRepository carRepository)
    {
        _car = car;
        _typeOfCar = typeOfCar;
        _carRepository = carRepository;
        _navigateService = navigationService;
        _authenticationService = authService;

        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel ).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
        //LogoutCommand = new RelayCommand(() =>
        //{
        //    _authenticationService.Logout();
        //    CheckAuthenticationState();
        //});
        CheckAuthenticationState();
    }

    public async Task LoadInitialDataAsync()
    {
        await LoadCarsAsync();
        await LoadCategoriesAsync();
    }

    private async Task LoadCarsAsync()
    {
        var cars = await _car.GetAllAsync();
        Items = new FullObservableCollection<Car>(cars);
        foreach (var item in Items)
        {
           Task.Run(async () =>
           {
               item.VariantOfCars = await _carRepository.GetVariantsOfCar(item.CarId);
           }).Wait();
        }
        PopularCars = new FullObservableCollection<Car>(Items.Take(8).ToList());
        SuggestCars = new FullObservableCollection<Car>(Items.Take(10).ToList());
    }

    private async Task LoadCategoriesAsync()
    {
        var categories = await _typeOfCar.GetAllAsync();
        Categories = new FullObservableCollection<TypeOfCar>(categories);
    }

    private void CheckAuthenticationState()
    {
        var user = _authenticationService.GetCurrentUser();
        IsLogin = user != null;
        CurrentUser = user;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

