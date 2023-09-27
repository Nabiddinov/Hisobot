using Report.Application.DTO.Authentication;

namespace Report.Application.Service.AuthenticationService;

public interface IReportAuthenticationService
{
    Task<TokenDto> LoginAsync(AuthenticationDto authenticationDto);
    Task<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}
