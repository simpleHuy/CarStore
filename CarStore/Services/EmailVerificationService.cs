using System;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;

namespace CarStore.Services;

public class EmailVerificationService
{
    private readonly SmtpClient _smtpClient;
    private const int TOKEN_EXPIRY_HOURS = 24;

    // Mock storage using thread-safe collection
    private static readonly ConcurrentDictionary<string, VerificationRecord> _verificationRecords
        = new ConcurrentDictionary<string, VerificationRecord>();

    private static readonly ConcurrentDictionary<string, UserVerificationStatus> _userVerificationStatus
        = new ConcurrentDictionary<string, UserVerificationStatus>();

    public EmailVerificationService(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword)
    {
        _smtpClient = new SmtpClient(smtpHost, smtpPort)
        {
            EnableSsl = true,
            Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword)
        };
    }

    public async Task<bool> SendVerificationEmailAsync(string email, string username)
    {
        try
        {
            // Generate verification token
            var token = GenerateVerificationToken();
            var expiryDate = DateTime.UtcNow.AddHours(TOKEN_EXPIRY_HOURS);

            // Save verification record
            var verificationRecord = new VerificationRecord
            {
                Email = email,
                Token = token,
                ExpiryDate = expiryDate,
                CreatedAt = DateTime.UtcNow,
                IsVerified = false
            };

            _verificationRecords.TryAdd(token, verificationRecord);

            // Initialize user verification status if not exists
            _userVerificationStatus.TryAdd(email, new UserVerificationStatus
            {
                Email = email,
                IsEmailVerified = false,
                EmailVerifiedAt = null
            });

            // Create verification link
            var verificationLink = $"https://yourwebsite.com/verify?token={token}&email={Uri.EscapeDataString(email)}";

            // Create email message
            var mailMessage = new MailMessage
            {
                From = new MailAddress("noreply@yourwebsite.com", "Your Company Name"),
                Subject = "Verify Your Email Address",
                IsBodyHtml = true,
                Body = GenerateEmailBody(username, verificationLink)
            };
            mailMessage.To.Add(email);

            // Send email
            await _smtpClient.SendMailAsync(mailMessage);
            return true;
        }
        catch (Exception ex)
        {
            // Log the error
            Console.WriteLine($"Error sending verification email: {ex.Message}");
            return false;
        }
    }

    public async Task<VerificationResult> VerifyEmailAsync(string email, string token)
    {
        try
        {
            // Check if token exists
            if (!_verificationRecords.TryGetValue(token, out var record))
            {
                return new VerificationResult
                {
                    Success = false,
                    Message = "Invalid verification token."
                };
            }

            // Validate email matches
            if (record.Email != email)
            {
                return new VerificationResult
                {
                    Success = false,
                    Message = "Email does not match verification token."
                };
            }

            // Check if already verified
            if (record.IsVerified)
            {
                return new VerificationResult
                {
                    Success = false,
                    Message = "Email is already verified."
                };
            }

            // Check if token expired
            if (record.ExpiryDate < DateTime.UtcNow)
            {
                return new VerificationResult
                {
                    Success = false,
                    Message = "Verification token has expired."
                };
            }

            // Update verification status
            record.IsVerified = true;

            if (_userVerificationStatus.TryGetValue(email, out var status))
            {
                status.IsEmailVerified = true;
                status.EmailVerifiedAt = DateTime.UtcNow;
            }

            return new VerificationResult
            {
                Success = true,
                Message = "Email verified successfully."
            };
        }
        catch (Exception ex)
        {
            // Log the error
            Console.WriteLine($"Error verifying email: {ex.Message}");
            return new VerificationResult
            {
                Success = false,
                Message = "An error occurred during verification."
            };
        }
    }

    // Helper method to check verification status
    public bool IsEmailVerified(string email)
    {
        return _userVerificationStatus.TryGetValue(email, out var status) && status.IsEmailVerified;
    }

    // Helper method to get verification timestamp
    public DateTime? GetEmailVerificationTime(string email)
    {
        return _userVerificationStatus.TryGetValue(email, out var status) ? status.EmailVerifiedAt : null;
    }

    private string GenerateVerificationToken()
    {
        var tokenBytes = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(tokenBytes);
        }
        return Convert.ToBase64String(tokenBytes)
            .Replace("/", "_")
            .Replace("+", "-")
            .Replace("=", "");
    }

    private string GenerateEmailBody(string username, string verificationLink)
    {
        return $@"
            <html>
            <body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>
                <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                    <h2>Welcome to Our Service!</h2>
                    <p>Hello {username},</p>
                    <p>Thank you for registering. Please verify your email address by clicking the button below:</p>
                    <div style='text-align: center; margin: 30px 0;'>
                        <a href='{verificationLink}' 
                           style='background-color: #4CAF50; color: white; padding: 12px 25px; 
                                  text-decoration: none; border-radius: 3px; display: inline-block;'>
                            Verify Email Address
                        </a>
                    </div>
                    <p>Or copy and paste this link into your browser:</p>
                    <p style='word-break: break-all; color: #666;'>{verificationLink}</p>
                    <p>This verification link will expire in {TOKEN_EXPIRY_HOURS} hours.</p>
                    <p>If you didn't create an account, you can safely ignore this email.</p>
                    <hr style='border: none; border-top: 1px solid #eee; margin: 20px 0;'>
                    <p style='font-size: 12px; color: #666;'>
                        This is an automated message, please do not reply to this email.
                    </p>
                </div>
            </body>
            </html>";
    }
}

// Model classes for mock data storage
public class VerificationRecord
{
    public string Email
    {
        get; set;
    }
    public string Token
    {
        get; set;
    }
    public DateTime ExpiryDate
    {
        get; set;
    }
    public DateTime CreatedAt
    {
        get; set;
    }
    public bool IsVerified
    {
        get; set;
    }
}

public class UserVerificationStatus
{
    public string Email
    {
        get; set;
    }
    public bool IsEmailVerified
    {
        get; set;
    }
    public DateTime? EmailVerifiedAt
    {
        get; set;
    }
}

public class VerificationResult
{
    public bool Success
    {
        get; set;
    }
    public string Message
    {
        get; set;
    }
}