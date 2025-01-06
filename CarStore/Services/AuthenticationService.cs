using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using CarStore.Contracts.Services;
using CarStore.Core.Contracts.Repository;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CarStore.Services.DataAccess;
using CarStore.ViewModels;
using Windows.Networking.Sockets;
using Windows.Storage;

namespace CarStore.Services;


public class AuthenticationService : IAuthenticationService
{
    private readonly string _userDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userData.json");
    private User? _currentUser;
    private readonly IDao<User> userDao;
    private readonly IUserRepository userRepository;

    private const int MIN_PASSWORD_LENGTH = 8;
    private const int MAX_NAME_LENGTH = 50;
    private const string EMAIL_PATTERN = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    private const string PHONE_PATTERN = @"^(0|\+84)[0-9]{9}$";
    private const string PASSWORD_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
    public AuthenticationService(IDao<User>userDao, IUserRepository userRepository)
    {
        _currentUser = null;
        this.userDao = userDao;
        this.userRepository = userRepository;
        AuthStateChanged = delegate { };
    }

    private readonly User _userDefault = new()
    {
        Id = 1,
        Email = "example@gmail.com",
        Telephone = "0333601234",
        AccountType = "Hội viên tiềm năng",
        firstName = "Admin",
        lastName = "Nguyễn",
    };

    public event EventHandler<AuthStateChangedEventArgs> AuthStateChanged;
    private bool _isAuthenticated;
    public bool IsAuthenticated
    {
        get => _isAuthenticated;
        private set
        {
            if (_isAuthenticated != value)
            {
                _isAuthenticated = value;
                // Khi trạng thái thay đổi, kích hoạt sự kiện AuthStateChanged
                OnAuthStateChanged(new AuthStateChangedEventArgs(_isAuthenticated));
            }
        }
    }
    protected virtual void OnAuthStateChanged(AuthStateChangedEventArgs e)
    {
        AuthStateChanged?.Invoke(this, e);
    }

    public void Logout()
    {
        _currentUser = null;
        IsAuthenticated = false;
    }

    public User GetCurrentUser()
    {
        return _currentUser;
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
    public bool VerifyEmail(string email)
    {
        // 
        return Regex.IsMatch(email, EMAIL_PATTERN);
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        Task.Run(async () =>
        {
            if (username == "admin" && password == "1234")
            {
                _currentUser = _userDefault;
                return true;
            }

            if (username == "anycar" && password == "1234")
            {
                _currentUser = await userDao.GetByIdAsync(2);
                return true;
            }

            if (username == "starupshow" && password == "1234")
            {
                _currentUser = await userDao.GetByIdAsync(3);
                return true;
            }

            var userData = await userRepository.GetUserByUsername(username);
            if (userData == null)
            {
                return false;
            }

            var hashedPassword = HashPassword(password, userData.Salt);
            if (hashedPassword == userData.PasswordHash)
            {
                _currentUser = userData;
                return true;
            }

            return false;
        }).Wait();
        if (_currentUser != null)
        {
            IsAuthenticated = true;
            return true;
        }
        return false;

    }
    public ValidationResult ValidateRegistrationData(
        string firstName,
        string lastName,
        string email,
        string phoneNumber,
        string username,
        string password,
        string confirmPassword)
    {
        // Check for empty fields
        if (string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(phoneNumber) ||
            string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Tất cả các trường là bắt buộc."
            };
        }

        // Validate names
        if (!ValidateName(firstName))
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Tên không hợp lệ. Tên không được chứa số và không quá 50 ký tự."
            };

        if (!ValidateName(lastName))
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Họ không hợp lệ. Họ không được chứa số và không quá 50 ký tự."
            };

        // Validate email
        if (!ValidateEmail(email))
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Email không hợp lệ."
            };

        // Validate phone number
        if (!ValidatePhoneNumber(phoneNumber))
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Số điện thoại không hợp lệ. Vui lòng sử dụng định dạng: 0xxxxxxxxx hoặc +84xxxxxxxxx"
            };

        // Validate username
        if (username.Length < 3 || username.Length > 20)
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Tên đăng nhập phải từ 3 đến 20 ký tự."
            };

        var existingUsername = new User();
        var existingEmail = new User();
        Task.Run(async () =>
        {
            existingUsername = await userRepository.GetUserByUsername(username);
            existingEmail = await userRepository.GetUserByEmail(email);
        }).Wait();

        if (existingUsername != null)
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Tên đăng nhập đã tồn tại."
            };
        if (existingEmail != null)
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Email đã tồn tại."
            };

        // Validate password
        if (!ValidatePassword(password))
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt."
            };

        // Check password match
        if (password != confirmPassword)
            return new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Mật khẩu không trùng khớp."
            };

        return new ValidationResult { IsValid = true, ErrorMessage = string.Empty };
    }

    private bool ValidateEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, EMAIL_PATTERN);
    }

    private bool ValidatePhoneNumber(string phoneNumber)
    {
        return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, PHONE_PATTERN);
    }

    private bool ValidatePassword(string password)
    {
        return !string.IsNullOrWhiteSpace(password) && Regex.IsMatch(password, PASSWORD_PATTERN);
    }

    private bool ValidateName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) &&
               name.Length <= MAX_NAME_LENGTH &&
               !name.Any(char.IsDigit);
    }

    // Modified Register method
    public async Task<bool> RegisterAsync(string firstName, string lastName, string email, string phoneNumber, string username, string password)
    {
        var validationResult = ValidateRegistrationData(firstName, lastName, email, phoneNumber, username, password, password);
        if (!validationResult.IsValid)
            return await Task.FromResult(false);

        // Sanitize inputs
        firstName = firstName.Trim();
        lastName = lastName.Trim();
        email = email.Trim().ToLower();
        phoneNumber = phoneNumber.Trim();
        username = username.Trim();

        var salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
        var hashedPassword = HashPassword(password, salt);

        var newUser = new User()
        {
            Username = username,
            PasswordHash = hashedPassword,
            Salt = salt,
            Email = email,
            firstName = firstName,
            lastName = lastName,
            Telephone = phoneNumber
        };

        await userDao.Insert(newUser);

        return await Task.FromResult(true);
    }

    public async Task<bool> ResetPasswordAsync(string email)
    {
        var user = await userRepository.GetUserByEmail(email);
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

        var user = await userRepository.GetUserByUsername(username);

        user.PasswordHash = hashedPassword;
        user.Salt = salt;

        await userDao.Update(user);
        return true;
    }

    private string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        using var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(32);
        return Convert.ToBase64String(hash);
    }
    //----------------------------------------------------------------------------
    public async Task<bool> ValidateUsernameExistsAsync(string username)
    {
        var user = await userRepository.GetUserByUsername(username);
        return user != null;
    }

    // New method to validate password reset data


    // New method to reset password
    public async Task<bool> ResetPasswordAsync(string username, string newPassword)
    {
        try
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(newPassword))
            {
                return false;
            }

            return await Task.Run(async () =>
            {
                var user = await userRepository.GetUserByUsername(username);

                if (user == null)
                    return false;

                var salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
                var hashedPassword = HashPassword(newPassword, salt);

                user.PasswordHash = hashedPassword;
                user.Salt = salt;

                await userDao.Update(user);

                return true;
            });
        }
        catch (Exception)
        {
            // Log error in production
            return false;
        }
    }

    // Modified method to properly implement async operations
    public async Task<bool> ConfirmPasswordResetAsync(string username, string newPassword, string confirmPassword)
    {
        try
        {
            // Run validation on a background thread since it involves CPU-bound operations
            var validationResult = await Task.Run(() =>
                ValidatePasswordReset(username, newPassword, confirmPassword));

            if (!validationResult.IsValid)
                return false;

            // Call the async reset method
            return await ResetPasswordAsync(username, newPassword);
        }
        catch (Exception)
        {
            // Log error in production
            return false;
        }
    }

    // Helper method for password validation
    public PasswordResetValidationResult ValidatePasswordReset(string username, string newPassword, string confirmPassword)
    {
        // Check for empty fields
        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(newPassword) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            return new PasswordResetValidationResult
            {
                IsValid = false,
                ErrorMessage = "Tất cả các trường là bắt buộc.",
                UserExists = false
            };
        }

        // Check if user exists
        var user = new User();
        Task.Run(async () =>
        {
            user = await userRepository.GetUserByUsername(username);
        }).Wait();
        if (user == null)
        {
            return new PasswordResetValidationResult
            {
                IsValid = false,
                ErrorMessage = "Tên đăng nhập không tồn tại.",
                UserExists = false
            };
        }

        // Validate new password
        if (!ValidatePassword(newPassword))
        {
            return new PasswordResetValidationResult
            {
                IsValid = false,
                ErrorMessage = "Mật khẩu mới phải có ít nhất 12 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.",
                UserExists = true
            };
        }

        // Check if passwords match
        if (newPassword != confirmPassword)
        {
            return new PasswordResetValidationResult
            {
                IsValid = false,
                ErrorMessage = "Mật khẩu mới không trùng khớp.",
                UserExists = true
            };
        }

        return new PasswordResetValidationResult
        {
            IsValid = true,
            ErrorMessage = string.Empty,
            UserExists = true
        };
    }

    // Add to existing ValidatePassword method or create a new one for validation only
    public bool ValidatePasswordStrength(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        var hasNumber = password.Any(char.IsDigit);
        var hasUpperCase = password.Any(char.IsUpper);
        var hasLowerCase = password.Any(char.IsLower);
        var hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));
        var isLengthValid = password.Length >= MIN_PASSWORD_LENGTH;

        return hasNumber && hasUpperCase && hasLowerCase && hasSpecialChar && isLengthValid;
    }
    public void ResetUserDataFile()
    {
        if (File.Exists(_userDataPath))
        {
            File.Delete(_userDataPath);
        }
    }
}