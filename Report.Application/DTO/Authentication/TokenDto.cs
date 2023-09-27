namespace Report.Application.DTO.Authentication;

public record TokenDto(
string accessToken,
string? refreshToken,
DateTime expireDate);
