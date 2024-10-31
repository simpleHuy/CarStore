using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CarStore.Contracts.Services;
using CarStore.Contracts.ViewModels;

namespace CarStore.ViewModels;

public partial class VerifyViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IAuthenticationService _authService;

    private string _username = string.Empty;
    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    public IRelayCommand VerifyCommand
    {
        get;
    }

    public IRelayCommand ResendCommand
    {
        get;
    }

    public IRelayCommand NavigateToForgotPassword { get; }

    public VerifyViewModel(INavigationService navigationService, IAuthenticationService authService)
    {
        _navigationService = navigationService;
        _authService = authService;
        //VerifyCommand = new RelayCommand(ExecuteVerify);
        //ResendCommand = new RelayCommand(ExecuteResend);
        NavigateToForgotPassword = new RelayCommand(() => _navigationService.NavigateTo(typeof(ForgotPasswordViewModel).FullName!));
    }

    private async Task ExecuteVerify()
    {
        try
        {

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task ExecuteResend()
    {
        try
        {

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
