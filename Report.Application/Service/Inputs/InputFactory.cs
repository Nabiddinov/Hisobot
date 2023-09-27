using Report.Application.DTO.Input;
using Report.Application.DTO.Users;
using Report.Domain.Entities;

namespace Report.Application.Service.Inputs;

public class InputFactory : IInputFactory
{
    public Input MapToInput(InputForCreationDto inputForCreationDto, Guid userId)
    {

        return new Input
        {
          Summa=inputForCreationDto.summa,
          UserId=userId,
          Category=inputForCreationDto.category,
          Comment=inputForCreationDto.comment,
          AddedTime=inputForCreationDto.addedTime ?? DateTime.UtcNow.Date
    };
    }

    public void MapToInput(Input storageInput, InputForModificationDto inputForCreationDto)
    {
        storageInput.Summa = inputForCreationDto.summa ?? storageInput.Summa;
        storageInput.Category = inputForCreationDto.category ?? storageInput.Category;
        storageInput.Comment = inputForCreationDto.comment ?? storageInput.Comment;
        storageInput.AddedTime = inputForCreationDto.addedTime ?? storageInput.AddedTime;
    }

    public InputDto MapToInputDto(Input input)
    {
        return new InputDto(
            input.Id,
            input.Summa,
            input.Category,
            input.Comment,
            input.AddedTime);
    }
}
