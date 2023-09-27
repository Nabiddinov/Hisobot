using Report.Domain.Enums;

namespace Report.Application.DTO.Users;

public record UserDto(
    Guid id,
    string familyName,
    string email,
    UserRole role);