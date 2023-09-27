using Report.Domain.Enums;

namespace Report.Domain.Entities;

public class User
{
    private const int DEFAULT_EXPIRE_DATE_IN_MINUTES = 1440;
    public Guid Id { get; set; }
    public string FamilyName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpireDate { get; private set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }

    public void UpdateRefreshToken(
        string refreshToken,
        int expireDateInMinutes = DEFAULT_EXPIRE_DATE_IN_MINUTES)
    {
        RefreshToken = refreshToken;

        RefreshTokenExpireDate = DateTime.UtcNow
            .AddMinutes(expireDateInMinutes);
    }
}
