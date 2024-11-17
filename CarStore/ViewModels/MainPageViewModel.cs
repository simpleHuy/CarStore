using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CarStore.Contracts.Services;
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

public class MainPageViewModel : ObservableObject
{
    private readonly IDao<Car> _car;
    private readonly IDao<TypeOfCar> _typeOfCar;
    public event PropertyChangedEventHandler? PropertyChanged;
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

    public FullObservableCollection<Car>? Items
    {
        get; set;
    }

    public FullObservableCollection<TypeOfCar>? Categories
    {
        get; set;
    }

    public FullObservableCollection<Car>? PopularCars { get; set; }
    public ObservableCollection<Car>? SuggestCars { get; set; }

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
    public MainPageViewModel(INavigationService navigationService, IAuthenticationService authService, IDao<Car> car, IDao<TypeOfCar> typeOfCar)
    {
        _car = car;
        _typeOfCar = typeOfCar;
        _navigateService = navigationService;
        _authenticationService = authService;

        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
        //LogoutCommand = new RelayCommand(() =>
        //{
        //    _authenticationService.Logout();
        //    CheckAuthenticationState();
        //});
        CheckAuthenticationState();
    }

    public async Task LoadCarsAsync()
    {
        var cars = await _car.GetAllAsync();
        Items = new FullObservableCollection<Car>(cars);
        PopularCars = new FullObservableCollection<Car>(Items.Take(8).ToList());
        SuggestCars = new FullObservableCollection<Car>(Items.Take(10).ToList());
    }

    public async Task LoadCategoriesAsync()
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
}

