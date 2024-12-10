using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarStore.ViewModels;
public class AccountPageViewModel: ObservableObject, INotifyPropertyChanged
{
    public readonly ICarRepository _carRepository;
    private readonly IDao<Car> _carDao;
    private readonly IDao<Variant> _variantDao;
    public readonly INavigationService _navigateService;
    public readonly IAuthenticationService _authenticationService;
    public IRelayCommand NavigateToLoginCommand
    {
        get;
    }
    public IRelayCommand NavigateToSignupCommand
    {
        get;
    }
    public ObservableCollection<Car>? Wishlist
    {
        get; set;
    }

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

    public User? ViewedUser
    {
        get; set;
    }

    public AccountPageViewModel(INavigationService navigationService, IAuthenticationService authService, ICarRepository carRepository, IDao<Car> carDao, IDao<Variant> variantdao)
    {
        _carDao = carDao;
        _carRepository = carRepository;
        _navigateService = navigationService;
        _authenticationService = authService;
        _variantDao = variantdao;

        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
        Task.Run(async () =>
        {
            Wishlist = new ObservableCollection<Car>(await _carDao.GetAllAsync());
            foreach (var car in Wishlist)
            {
                car.VariantOfCars = await _carRepository.GetVariantsOfCar(car.CarId);
                foreach (var variant in car.VariantOfCars)
                {
                    variant.Variant = await _variantDao.GetByIdAsync(variant.VariantId);
                }
            }
        }).Wait();

        CheckAuthenticationState();
    }

    private void CheckAuthenticationState()
    {
        var user = _authenticationService.GetCurrentUser();
        CurrentUser = user;
        ViewedUser = user;
    }
}
