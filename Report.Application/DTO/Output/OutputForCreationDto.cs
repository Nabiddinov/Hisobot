using Report.Domain.Enums;

namespace Report.Application.DTO.Output;

public record OutputForCreationDto(
    double summa,
    OutputCategory category,
    string? comment,
    DateTime? addedTime);