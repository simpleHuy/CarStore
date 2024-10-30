using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace CarStore.Contracts.Services;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(string username, string password);
    Task<bool> RegisterAsync(string firstName, string lastName, string email, string phoneNumber, string userName, string password);
    Task<bool> ResetPasswordAsync(string email);
    Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword);
    Task SaveCredentialsAsync(string username, string password);
    Task<(string username, string password)?> GetSavedCredentialsAsync();
    Task ClearSavedCredentialsAsync();
    bool ValidatePassword(string password);
}