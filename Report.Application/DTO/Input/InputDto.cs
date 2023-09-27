using Report.Domain.Enums;

namespace Report.Application.DTO.Input;

public record InputDto(
    Guid id,
    double summa,
    InputCategory category,
    string? comment,
    DateTime addedTime);