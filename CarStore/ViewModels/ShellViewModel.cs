using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using CarStore.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Services;
using CarStore.Views;

using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace CarStore.ViewModels;

public partial class ShellViewModel : ObservableRecipient, INotifyPropertyChanged
{
    [ObservableProperty]
    private bool isBackEnabled;

    [ObservableProperty]
    private object? selected;

    public readonly IAuthenticationService AuthenticationService;

    private bool _isLogin;
    public bool IsLogin
    {
        get => _isLogin;
        set
        {
            if (_isLogin != value)
            {
                _isLogin = value;
                OnPropertyChanged(nameof(IsLogin)); // Thông báo UI khi giá trị thay đổi
            }
        }
    }

    private void OnAuthStateChanged(object sender, AuthStateChangedEventArgs e)
    {
        // Cập nhật IsLogin khi trạng thái đăng nhập thay đổi
        IsLogin = e.IsAuthenticated;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public INavigationService NavigationService
    {
        get;
    }

    public INavigationViewService NavigationViewService
    {
        get;
    }

    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService, IAuthenticationService authenticationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
        AuthenticationService = authenticationService;

        IsLogin = AuthenticationService.GetCurrentUser() != null;

        AuthenticationService.AuthStateChanged += OnAuthStateChanged;
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;
        var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem != null)
        {
            Selected = selectedItem;
        }
    }
}
