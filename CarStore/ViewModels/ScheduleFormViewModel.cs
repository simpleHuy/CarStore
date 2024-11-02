using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Models;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarStore.ViewModels;
public class ScheduleFormViewModel:ObservableObject, INotifyPropertyChanged
{
    public ScheduleFormViewModel(INavigationService navigationService)
    {
        isLogin = true;
        CurrentUser = dao.getCurrentUser();
        _navigateService = navigationService;
        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
        CurrentSelectedCar = dao.getAllCars().FirstOrDefault() ?? new Car();
    }

    private readonly IDao dao = new MockDao();
    public event PropertyChangedEventHandler? PropertyChanged;
    public readonly INavigationService _navigateService;
    public IRelayCommand NavigateToLoginCommand{get;}
    public IRelayCommand NavigateToSignupCommand{get;}
    public User CurrentUser{get; set;}
    public bool isLogin{get; set;}
    public Car CurrentSelectedCar{get; set;}
    public List<string?> SelectedCarImages{get; set;}
    public Color SelectedCarColor{get; set;}
    
}
