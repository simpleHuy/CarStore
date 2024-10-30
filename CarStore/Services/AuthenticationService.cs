using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Windows.Storage;
using CarStore.Contracts.Services;

namespace CarStore.Services;


public class AuthenticationService : IAuthenticationService
{
    private readonly string _userDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userData.json");
    private Dictionary<string, UserData> _users;

    public AuthenticationService()
    {
        _users = new Dictionary<string, UserData>();
        LoadUsers();
    }

    private class UserData
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;

    }

    private void LoadUsers()
    {
        if (File.Exists(_userDataPath))
        {
            var json = File.ReadAllText(_userDataPath);
            _users = JsonSerializer.Deserialize<Dictionary<string, UserData>>(json) ?? new Dictionary<string, UserData>();
        }
        else
        {
            _users = new Dictionary<string, UserData>();
        }
    }

    private void SaveUsers()
    {
        var json = JsonSerializer.Serialize(_users);
        File.WriteAllText(_userDataPath, json);
    }

    public async Task SaveCredentialsAsync(string username, string password)
    {
        try
        {
            // Convert password to bytes
            var passwordInBytes = Encoding.UTF8.GetBytes(password);

            // Generate random entropy
            var entropyInBytes = new byte[20];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(entropyInBytes);
            }

            // Encrypt password using DPAPI
            var encryptedPassword = ProtectedData.Protect(
                passwordInBytes,
                entropyInBytes,
                DataProtectionScope.CurrentUser);

            // Convert to Base64 for storage
            var encryptedPasswordInBase64 = Convert.ToBase64String(encryptedPassword);
            var entropyInBase64 = Convert.ToBase64String(entropyInBytes);

            // Save to local settings
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values["username"] = username;
            localSettings.Values["password"] = encryptedPasswordInBase64;
            localSettings.Values["entropy"] = entropyInBase64;

            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            // Log the error in production
            throw new Exception("Failed to save credentials", ex);
        }
    }

    public async Task<(string username, string password)?> GetSavedCredentialsAsync()
    {
        try
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            if (!localSettings.Values.ContainsKey("username") ||
                !localSettings.Values.ContainsKey("password") ||
                !localSettings.Values.ContainsKey("entropy"))
            {
                return null;
            }

            var username = localSettings.Values["username"]?.ToString();
            var encryptedPasswordInBase64 = localSettings.Values["password"]?.ToString();
            var entropyInBase64 = localSettings.Values["entropy"]?.ToString();

            if (username == null || encryptedPasswordInBase64 == null || entropyInBase64 == null)
            {
                return null;
            }

            var encryptedPasswordInBytes = Convert.FromBase64String(encryptedPasswordInBase64);
            var entropyInBytes = Convert.FromBase64String(entropyInBase64);

            var passwordInBytes = await Task.Run(() => ProtectedData.Unprotect(
                encryptedPasswordInBytes,
                entropyInBytes,
                DataProtectionScope.CurrentUser));

            var password = Encoding.UTF8.GetString(passwordInBytes);

            return (username, password);
        }
        catch (Exception)
        {
            // Log the error in production
            return null;
        }
    }

    public async Task ClearSavedCredentialsAsync()
    {
        var localSettings = ApplicationData.Current.LocalSettings;
        localSettings.Values.Remove("username");
        localSettings.Values.Remove("password");
        localSettings.Values.Remove("entropy");
        await Task.CompletedTask;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        return await Task.Run(() =>
        {
            // For demo purposes - replace with your actual authentication logic
            if (username == "admin" && password == "1234")
            {
                return true;
            }

            // Or use the existing user storage system:
            /*
            if (!_users.ContainsKey(username))
                return false;

            var userData = _users[username];
            var hashedPassword = HashPassword(password, userData.Salt);
            return hashedPassword == userData.PasswordHash;
            */

            return false;
        });
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string email, string phoneNumber, string username, string password)
    {
        if (_users.ContainsKey(username))
            return await Task.FromResult(false);

        if (!ValidatePassword(password))
            return await Task.FromResult(false);
        if (string.IsNullOrEmpty(email))
            return await Task.FromResult(false);
        if (string.IsNullOrEmpty(phoneNumber))
            return await Task.FromResult(false);
        if (string.IsNullOrEmpty(firstName))
            return await Task.FromResult(false);
        if (string.IsNullOrEmpty(lastName))
            return await Task.FromResult(false);



        var salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
        var hashedPassword = HashPassword(password, salt);

        _users[username] = new UserData
        {
            Username = username,
            PasswordHash = hashedPassword,
            Salt = salt,
            Email = email,
            firstName = firstName,
            lastName = lastName,
            phoneNumber = phoneNumber
        };

        SaveUsers();
        return await Task.FromResult(true);
    }

    public async Task<bool> ResetPasswordAsync(string email)
    {
        var user = await Task.Run(() => _users.Values.FirstOrDefault(u => u.Email == email));
        if (user == null)
            return false;

        // In a real application, implement password reset logic here
        return true;
    }

    public async Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword)
    {
        if (!await LoginAsync(username, oldPassword))
            return false;

        if (!ValidatePassword(newPassword))
            return false;

        var salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
        var hashedPassword = HashPassword(newPassword, salt);

        _users[username].PasswordHash = hashedPassword;
        _users[username].Salt = salt;

        SaveUsers();
        return true;
    }

    private string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(32);
        return Convert.ToBase64String(hash);
    }

    public bool ValidatePassword(string password)
    {
        return password.Length >= 4; // Simplified for demo - enhance as needed
    }
}