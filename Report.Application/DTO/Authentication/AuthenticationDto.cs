namespace Report.Application.DTO.Authentication;

public record AuthenticationDto(
        string email,
        string password);