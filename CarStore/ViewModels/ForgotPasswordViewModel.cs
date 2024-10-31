using CarStore.Contracts.Services;
using CarStore.Services;
using CarStore.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace CarStore.ViewModels;

public class ForgotPasswordViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IAuthenticationService _authService;

    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _confirmPassword = string.Empty;
    private string _errorMessage = string.Empty;
    private string _successMessage = string.Empty;
    private bool _isLoading;
    private bool _rememberMe;

    public string Username
    {
        get => _username;
        set
        {
            if (SetProperty(ref _username, value))
            {
                ForgotPasswordCommand.NotifyCanExecuteChanged();
                ValidateUsername();
            }
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (SetProperty(ref _password, value))
            {
                ForgotPasswordCommand.NotifyCanExecuteChanged();
                ValidatePassword();
            }
        }
    }

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            if (SetProperty(ref _confirmPassword, value))
            {
                ForgotPasswordCommand.NotifyCanExecuteChanged();
                ValidateConfirmPassword();
            }
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public string SuccessMessage
    {
        get => _successMessage;
        set => SetProperty(ref _successMessage, value);
    }

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    public bool RememberMe
    {
        get => _rememberMe;
        set => SetProperty(ref _rememberMe, value);
    }

    public IAsyncRelayCommand ForgotPasswordCommand
    {
        get;
    }
    public IRelayCommand NavigateToLoginCommand
    {
        get;
    }

    public ForgotPasswordViewModel(INavigationService navigationService, IAuthenticationService authService)
    {
        _navigationService = navigationService;
        _authService = authService;
        NavigateToLoginCommand = new RelayCommand(ExecuteNavigateToLogin);
        ForgotPasswordCommand = new AsyncRelayCommand(ExecuteForgotPasswordAsync, CanExecuteForgotPassword);
    }

    private bool CanExecuteForgotPassword()
    {
        return !string.IsNullOrWhiteSpace(Username) &&
               !string.IsNullOrWhiteSpace(Password) &&
               !string.IsNullOrWhiteSpace(ConfirmPassword) &&
               !IsLoading;
    }

    private async void ValidateUsername()
    {
        if (string.IsNullOrWhiteSpace(Username))
        {
            ErrorMessage = "Vui lòng nhập tên đăng nhập.";
            return;
        }

        var userExists = await _authService.ValidateUsernameExistsAsync(Username);
        if (!userExists)
        {
            ErrorMessage = "Tên đăng nhập không tồn tại.";
        }
        else
        {
            ErrorMessage = string.Empty;
        }
    }

    private void ValidatePassword()
    {
        if (string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Vui lòng nhập mật khẩu mới.";
            return;
        }

        if (!(_authService as AuthenticationService)?.ValidatePasswordStrength(Password) ?? false)
        {
            ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.";
        }
        else
        {
            ErrorMessage = string.Empty;
        }
    }

    private void ValidateConfirmPassword()
    {
        if (string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            ErrorMessage = "Vui lòng xác nhận mật khẩu mới.";
            return;
        }

        if (Password != ConfirmPassword)
        {
            ErrorMessage = "Mật khẩu xác nhận không trùng khớp.";
        }
        else
        {
            ErrorMessage = string.Empty;
        }
    }

    private async Task ExecuteForgotPasswordAsync()
    {
        try
        {
            IsLoading = true;
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;

            // Validate password reset data
            var validationResult = (_authService as AuthenticationService)?.ValidatePasswordReset(
                Username, Password, ConfirmPassword);

            if (validationResult != null && !validationResult.IsValid)
            {
                ErrorMessage = validationResult.ErrorMessage;
                return;
            }

            // Attempt to reset password
            var resetSuccess = await _authService.ConfirmPasswordResetAsync(Username, Password, ConfirmPassword);

            if (resetSuccess)
            {
                SuccessMessage = "Đặt lại mật khẩu thành công!";
                if (RememberMe)
                {
                    await _authService.SaveCredentialsAsync(Username, Password);
                }
                else
                {
                    await _authService.ClearSavedCredentialsAsync();
                }

                // Wait a brief moment to show success message before navigating
                await Task.Delay(1500);
                _navigationService.NavigateTo(typeof(LoginViewModel).FullName!);
            }
            else
            {
                ErrorMessage = "Không thể đặt lại mật khẩu. Vui lòng thử lại sau.";
            }
        }
        catch (Exception)
        {
            ErrorMessage = "Đã xảy ra lỗi khi đặt lại mật khẩu. Vui lòng thử lại sau.";
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void ExecuteNavigateToLogin()
    {
        _navigationService.NavigateTo(typeof(LoginViewModel).FullName!);
    }
}