using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Services;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarStore.ViewModels;
public class ScheduleFormViewModel:ObservableObject, INotifyPropertyChanged
{
    public readonly INavigationService _navigateService;
    public readonly IAuthenticationService _authenticationService;
    private readonly IDao<Schedule> _scheduleDao;
    public ScheduleFormViewModel(IAuthenticationService authenticationService,INavigationService navigateService, IDao<Schedule> scheduleDao)
    {
        _authenticationService = authenticationService;
        _navigateService = navigateService;
        _scheduleDao = scheduleDao;
        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
    }
    public User User
    {
        get => _authenticationService.GetCurrentUser();
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    public IRelayCommand NavigateToLoginCommand{get;}
    public IRelayCommand NavigateToSignupCommand{get;}
    public Car CurrentSelectedCar{get; set;}
    public Showroom Showroom
    {
        get; set;
    }

    public void AddSchedule(DateTime dateTime, string address)
    {
        DateTime utcDateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

        Schedule schedule = new Schedule
       {
           Date = utcDateTime,
           Address = address,
           CarId = CurrentSelectedCar.CarId,
           CustomerId = User.Id,
           MerchantId = Showroom.UserId
       };
        _scheduleDao.Insert(schedule);
    }
}
