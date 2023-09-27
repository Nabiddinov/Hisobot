using Report.Domain.Enums;

namespace Report.Application.DTO.Input;

public record InputForCreationDto(
        double summa,
        InputCategory category,
        string? comment,
        DateTime? addedTime);
