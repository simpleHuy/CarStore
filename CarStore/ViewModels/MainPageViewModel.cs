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

    public List<TypeOfCar> Categories
    {
        get; set;
    }

    public List<Car>? PopularCars
    {
        get; set;
    }

    public List<Car>? SuggestCars 
    {
        get; set;
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
        Task.Run(async() =>
        {
            SuggestCars = await _car.GetAllAsync();
            foreach (var car in SuggestCars) 
            { 
                car.VariantOfCars = await _carRepository.GetVariantsOfCar(car.CarId);
            }
            Categories = await _typeOfCar.GetAllAsync();
            PopularCars = SuggestCars; // Due to lack of data, we use the same data for both
        }).Wait();
        //LogoutCommand = new RelayCommand(() =>
        //{
        //    _authenticationService.Logout();
        //    CheckAuthenticationState();
        //});
        CheckAuthenticationState();
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

