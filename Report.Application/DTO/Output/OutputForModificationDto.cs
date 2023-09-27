using Report.Domain.Enums;

namespace Report.Application.DTO.Output;

public record OutputForModificationDto(
    Guid id,
    double? summa,
    OutputCategory? category,
    string? comment,
    DateTime? addedTime);