using Report.Domain.Enums;

namespace Report.Application.DTO.Users;

public record UserForModificationDto(
Guid userId,
string? familyName,
UserRole? userRole);
