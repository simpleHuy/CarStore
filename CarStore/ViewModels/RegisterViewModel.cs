using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarStore.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IAuthenticationService _authService;

    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _email = string.Empty;
    private string _phoneNumber = string.Empty;
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _confirmPassword = string.Empty;
    private string _errorMessage = string.Empty;

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (SetProperty(ref _firstName, value))
            {
                RegisterCommand.NotifyCanExecuteChanged();
            };
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (SetProperty(ref _lastName, value))
            {
                RegisterCommand.NotifyCanExecuteChanged();
            };
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (SetProperty(ref _email, value))
            {
                RegisterCommand.NotifyCanExecuteChanged();
            };
        }
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (SetProperty(ref _phoneNumber, value))
            {
                RegisterCommand.NotifyCanExecuteChanged();
            };
        }
    }

    public string Username
    {
        get => _username;
        set
        {
            if (SetProperty(ref _username, value))
            {
                RegisterCommand.NotifyCanExecuteChanged();
            };
        }  
    }

    public string Password
    {
        get => _password;
        set
        {
            if (SetProperty(ref _password, value))
            {
                RegisterCommand.NotifyCanExecuteChanged();
            };
        }
    }
    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            if (SetProperty(ref _confirmPassword, value))
            {
                RegisterCommand.NotifyCanExecuteChanged();
            };
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public IRelayCommand RegisterCommand
    {
        get;
    }

    public IRelayCommand NavigateToLoginCommand
    {
        get;
    }

    public RegisterViewModel(INavigationService navigationService, IAuthenticationService authService)
    {
        _navigationService = navigationService;
        _authService = authService;
        RegisterCommand = new AsyncRelayCommand(ExecuteRegister);
        NavigateToLoginCommand = new RelayCommand(() => _navigationService.NavigateTo(typeof(LoginViewModel).FullName!));
    }



    private async Task ExecuteRegister()
    {
        // Validate fields
        if (string.IsNullOrEmpty(FirstName) ||
            string.IsNullOrEmpty(LastName) ||
            string.IsNullOrEmpty(Email) ||
            string.IsNullOrEmpty(PhoneNumber) ||
            string.IsNullOrEmpty(Username) ||
            string.IsNullOrEmpty(Password) ||
            string.IsNullOrEmpty(ConfirmPassword))
        {
            ErrorMessage = "Tất cả các ô không để trống.";
            return;
        }

        if (Password != ConfirmPassword)
        {
            ErrorMessage = "Mật khẩu không trùng khớp.";
            return;
        }

        try
        {
            // Clear any previous error message
            ErrorMessage = string.Empty;

            // Save user data using the authentication service
            var registrationResult = await _authService.RegisterAsync(FirstName, LastName, Email, PhoneNumber, Username, Password);

            // Check if registration succeeded
            if (registrationResult)
            {
                // Navigate to LoginPage on successful registration
                _navigationService.NavigateTo(typeof(LoginViewModel).FullName!);
            }
            else
            {
                ErrorMessage = "Đăng ký thất bại. Vui lòng thử lại.";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Đã xảy ra lỗi: {ex.Message}";
        }
    }

}
