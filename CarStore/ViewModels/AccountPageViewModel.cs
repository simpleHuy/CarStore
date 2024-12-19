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
using Windows.Graphics.Printing3D;

namespace CarStore.ViewModels;
public class AccountPageViewModel: ObservableObject, INotifyPropertyChanged
{
    public readonly ICarRepository _carRepository;
    private readonly IUserRepository userRepository;
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
    public List<Car>? Wishlist
    {
        get; set;
    }
    public List<Schedule> Schedules
    {
        get; set;
    } = new List<Schedule>();

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

    public AccountPageViewModel(INavigationService navigationService, IAuthenticationService authService, IUserRepository userRepository,
                                ICarRepository carRepository, IDao<Variant> variantdao)
    {
        this.userRepository = userRepository;
        _carRepository = carRepository;
        _navigateService = navigationService;
        _authenticationService = authService;
        _variantDao = variantdao;

        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
        Task.Run(async () =>
        {
            var curUserId = _authenticationService.GetCurrentUser().Id;
            Schedules = await userRepository.GetSchedule(curUserId);
            Wishlist = await userRepository.GetWishlist(curUserId);
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
    }
}
