using System.Collections.ObjectModel;
using System.ComponentModel;
using CarStore.Contracts.Services;
using CarStore.Models;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace CarStore.ViewModels;

public class MainPageViewModel : ObservableObject, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public readonly INavigationService _navigateService;

    public ObservableCollection<Models.Car>? Items
    {
        get; set;
    }

    public ObservableCollection<Models.TypeOfCar>? Categories
    {
        get; set;
    }
    public IRelayCommand NavigateToLoginCommand { get;} // define functionc command
    public IRelayCommand NavigateToSignupCommand{ get;}
    public ObservableCollection<Models.Car>? PopularCars{get; set;}
    public ObservableCollection<Models.Car>? SuggestCars{get; set;}
    public User CurrentUser{get; set;}
    public bool isLogin{get;set;}
    public MainPageViewModel(INavigationService navigationService)
    {
        IDao dao = new MockDao();
        _navigateService = navigationService;

        NavigateToLoginCommand = new RelayCommand(()=> _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));

        Items = new ObservableCollection<Car>(dao.getAllCars());
        PopularCars = new ObservableCollection<Car>(dao.getPopularCars());
        SuggestCars = new ObservableCollection<Car>(dao.getSuggestCars());
        Categories = new ObservableCollection<TypeOfCar>(dao.GetTypeOfCar());
        CurrentUser = dao.getCurrentUser();
        isLogin = false;
    }


}

