using Report.Application.DTO.Input;

namespace Report.Application.Service.Inputs;

public interface IInputService
{
    ValueTask<InputDto> CreateInputAsync(InputForCreationDto inputForCreationDto,Guid userId);
    IQueryable<InputDto> RetrieveInputByDate(Guid userId,DateTime date);
    ValueTask<InputDto> ModifyInputAsync(InputForModificationDto inputForModificationDto);
    ValueTask<InputDto> RemoveInputAsync(Guid inputId);
    double MonthlySumAsync(Guid userId, DateTime date);
}
