using Report.Domain.Enums;

namespace Report.Application.DTO.Input;

public record InputForModificationDto(
    Guid id,
    double? summa,
    InputCategory? category,
    string? comment,
    DateTime? addedTime);