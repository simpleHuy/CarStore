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
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarStore.ViewModels;
public class AccountPageViewModel: ObservableObject
{
    public readonly ICarRepository _carRepository;
    public readonly IDao<Car> _carDao;
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
    public User CurrentUser
    {
        get; set;
    }

    public User ViewedUser
    {
        get; set;
    }

    public AccountPageViewModel(INavigationService navigationService, IAuthenticationService authService, ICarRepository carRepository, IDao<Car> carDao)
    {
        _carDao = carDao;
        _carRepository = carRepository;
        _navigateService = navigationService;
        _authenticationService = authService;

        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
        Task.Run(async () =>
        {
            Wishlist = new ObservableCollection<Car>(await _carDao.GetAllAsync());
        }).Wait();
    }
}
