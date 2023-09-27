using Report.Application.DTO.Input;
using Report.Domain.Entities;

namespace Report.Application.Service.Inputs;

public interface IInputFactory
{
    InputDto MapToInputDto(Input input);
    Input MapToInput(InputForCreationDto inputForCreationDto,Guid userId);
    void MapToInput(Input storageInput, InputForModificationDto InputForCreationDto);
}
