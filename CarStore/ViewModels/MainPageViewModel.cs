using System.Collections.ObjectModel;
using System.ComponentModel;
using CarStore.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarStore.ViewModels;

public class MainPageViewModel : ObservableObject
{
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

    public ObservableCollection<Car>? Items
    {
        get; set;
    }

    public ObservableCollection<TypeOfCar>? Categories
    {
        get; set;
    }

    public ObservableCollection<Car>? PopularCars { get; set; }
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
    public MainPageViewModel(INavigationService navigationService, IAuthenticationService authService)
    {
        IDao dao = new MockDao();
        _navigateService = navigationService;
        _authenticationService = authService;

        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
        //LogoutCommand = new RelayCommand(() =>
        //{
        //    _authenticationService.Logout();
        //    CheckAuthenticationState();
        //});

        Items = new ObservableCollection<Car>(dao.getAllCars());
        PopularCars = new ObservableCollection<Car>(dao.getPopularCars());
        SuggestCars = new ObservableCollection<Car>(dao.getSuggestCars());
        Categories = new ObservableCollection<TypeOfCar>(dao.GetTypeOfCar());
        CheckAuthenticationState();
    }

   
    private void CheckAuthenticationState()
    {
        var user = _authenticationService.GetCurrentUser();
        IsLogin = user != null;
        CurrentUser = user;
    }
}

