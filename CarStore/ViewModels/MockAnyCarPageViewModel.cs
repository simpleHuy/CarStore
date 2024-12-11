using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarStore.ViewModels;

public class MockAnyCarPageViewModel : ObservableObject, INotifyPropertyChanged
{
    public readonly ICarRepository _carRepository;
    public readonly IDao<Car> _carDao;
    public readonly IDao<Variant> _variantDao;
    public readonly INavigationService _navigateService;
    public readonly IAuthenticationService _authenticationService;
    public ObservableCollection<Car>? Wishlist
    {
        get; set;
    }
    public bool isLoggedIn = false;

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

    public MockAnyCarPageViewModel(INavigationService navigationService, IAuthenticationService authService, ICarRepository carRepository, IDao<Car> carDao, IDao<Variant> variantDao)
    {
        _carDao = carDao;
        _carRepository = carRepository;
        _navigateService = navigationService;
        _authenticationService = authService;
        _variantDao = variantDao;

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
        if (user != null)
        {
            isLoggedIn = true;
            CurrentUser = user;
        }
        ViewedUser = user;
    }
}
