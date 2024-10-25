using System.Threading.Tasks;
using CarStore.Contracts.Services;
using CarStore.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarStore.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    private string _firstName = "";
    private string _lastName = "";
    private string _email = "";
    private string _phoneNumber = "";
    private string _username = "";
    private string _password = "";
    private string _confirmPassword = "";
    private string _errorMessage = "";

    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => SetProperty(ref _phoneNumber, value);
    }

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

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set => SetProperty(ref _confirmPassword, value);
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

    public RegisterViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        RegisterCommand = new RelayCommand(ExecuteRegister);
    }

    private void ExecuteRegister()
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
            ErrorMessage = "All fields are required.";
            return;
        }

        if (Password != ConfirmPassword)
        {
            ErrorMessage = "Passwords do not match.";
            return;
        }

        // Clear any previous error message
        ErrorMessage = string.Empty;

        // Simulate a successful registration
        //Task.Delay(500).Wait(); // Replace with actual registration logic, e.g., API call

        // After registration, navigate to LoginPage
        _navigationService.NavigateTo(typeof(LoginViewModel).FullName!);
    }
}
