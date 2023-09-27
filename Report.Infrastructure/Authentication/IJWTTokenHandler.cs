using System.IdentityModel.Tokens.Jwt;
using Report.Domain.Entities;

namespace Test.Infrastructure.Authentication;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccessToken(User user);
    string GenerateRefreshToken();
}