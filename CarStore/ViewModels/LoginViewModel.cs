using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;

namespace CarStore.ViewModels;
public partial class LoginViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private string _username = "";
    private string _password = "";
    private string _errorMessage = "";

    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public IRelayCommand LoginCommand
    {
        get;
    }

    public LoginViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        LoginCommand = new RelayCommand(ExecuteLogin);
    }

    private void ExecuteLogin()
    {
        // Add your authentication logic here
        if (Username == "admin" && Password == "1234") // Replace with real auth
        {
            // Navigate to main page (Main)
            _navigationService.NavigateTo(typeof(MainViewModel).FullName!);
            //Frame.Navigate(typeof(MainPage));
        }
        else
        {
            ErrorMessage = "Tên đăng nhập hoặc mật khẩu không chính xác";
        }
    }
}
