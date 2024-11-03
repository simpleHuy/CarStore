using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using CarStore.Models;
using CarStore.Services;

namespace CarStore.Contracts.Services;

public class ValidationResult
{
    public bool IsValid
    {
        get; set;
    }
    public string ErrorMessage { get; set; } = string.Empty;
}

public class PasswordResetValidationResult
{
    public bool IsValid
    {
        get; set;
    }
    public string ErrorMessage { get; set; } = string.Empty;
    public bool UserExists
    {
        get; set;
    }
}
public interface IAuthenticationService
{

    Task<bool> LoginAsync(string username, string password);
    Task<bool> RegisterAsync(string firstName, string lastName, string email, string phoneNumber, string userName, string password);
    Task<bool> ResetPasswordAsync(string email);
    Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword);
    Task SaveCredentialsAsync(string username, string password);
    Task<(string username, string password)?> GetSavedCredentialsAsync();
    Task ClearSavedCredentialsAsync();
    //bool ValidatePassword(string password);
    ValidationResult ValidateRegistrationData(string firstName, string lastName, string email, string phoneNumber, string username, string password, string confirmPassword);
    Task<bool> ValidateUsernameExistsAsync(string username);
    PasswordResetValidationResult ValidatePasswordReset(string username, string newPassword, string confirmPassword);
    Task<bool> ConfirmPasswordResetAsync(string username, string newPassword, string confirmPassword);
    bool ValidatePasswordStrength(string password);
    Task<bool> ResetPasswordAsync(string username, string newPassword);

    bool VerifyEmail(string email);
    void Logout();

    User GetCurrentUser();
    event EventHandler<AuthStateChangedEventArgs> AuthStateChanged;
}