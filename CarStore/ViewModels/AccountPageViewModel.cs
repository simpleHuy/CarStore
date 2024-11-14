using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Services.DataAccess;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarStore.ViewModels;
public class AccountPageViewModel: ObservableObject
{
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
    public ObservableCollection<Models.Car>? Wishlist
    {
        get; set;
    }

    public AccountPageViewModel(INavigationService navigationService, IAuthenticationService authService)
    {
        IDao dao = new MockDao();
        _navigateService = navigationService;
        _authenticationService = authService;
        NavigateToLoginCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(LoginViewModel).FullName!));
        NavigateToSignupCommand = new RelayCommand(() => _navigateService.NavigateTo(typeof(RegisterViewModel).FullName!));
        Wishlist = new ObservableCollection<Models.Car>(dao.getPopularCars());
    }
}
