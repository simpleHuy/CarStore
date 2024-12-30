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
using Microsoft.EntityFrameworkCore;
using Windows.Graphics.Printing3D;

namespace CarStore.ViewModels;
public class AccountPageViewModel: ObservableObject, INotifyPropertyChanged
{
    public readonly ICarRepository _carRepository;
    private readonly IUserRepository userRepository;
    private readonly IShowroomRepository showroomRepository;
    private readonly IDao<Variant> _variantDao;
    private readonly IDao<Showroom> _showroomDao;
    private readonly IDao<RegisterDetail> _RegDao;
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
    public List<Car> OwnCar { get; set; } = new List<Car>();
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
                                ICarRepository carRepository, IDao<Variant> variantdao, IDao<Showroom> showroomDao, 
                                IShowroomRepository showroomRepository, IDao<RegisterDetail> regDao)
    {
        this.userRepository = userRepository;
        this.showroomRepository = showroomRepository;
        _carRepository = carRepository;
        _navigateService = navigationService;
        _authenticationService = authService;
        _variantDao = variantdao;
        _showroomDao = showroomDao;
        _RegDao = regDao;

        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
        Task.Run(async () =>
        {
            var curUserId = _authenticationService.GetCurrentUser().Id;
            Schedules = await userRepository.GetSchedule(curUserId);
            Wishlist = await userRepository.GetWishlist(curUserId);
            OwnCar = await userRepository.GetCarsOfUser(curUserId);
            foreach (var car in OwnCar)
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

    public bool CheckReputation()
    {
        var showroom = new Showroom();
        Task.Run(async () =>
        {
            showroom = await showroomRepository.GetShowroomByUserId(CurrentUser!.Id);
        }).Wait();
        return showroom.IsReputation;
    }

    public async void Register(string content)
    {
        DateTime utcDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

        var registerDetail = new RegisterDetail
        {
            UserId = CurrentUser!.Id,
            Content = content,
            CreatedDate = utcDateTime
        };

        await _RegDao.Insert(registerDetail);
    }

    public void Logout()
    {
        _authenticationService.Logout();
    }
}
