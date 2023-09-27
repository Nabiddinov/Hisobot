using Report.Application.DTO.Output;
using Report.Domain.Entities;

namespace Report.Application.Service.Outputs;

public class OutputFactory : IOutputFactory
{
    public Output MapToOutput(OutputForCreationDto outputForCreationDto, Guid userId)
    {
        return new Output
        {
            Summa = outputForCreationDto.summa,
            UserId = userId,
            Category = outputForCreationDto.category,
            Comment = outputForCreationDto.comment,
            AddedTime = outputForCreationDto.addedTime ?? DateTime.UtcNow.Date
        };
    }

    public void MapToOutput(Output storageOutput, OutputForModificationDto outputForCreationDto)
    {
        storageOutput.Summa = outputForCreationDto.summa ?? storageOutput.Summa;
        storageOutput.Category = outputForCreationDto.category ?? storageOutput.Category;
        storageOutput.Comment = outputForCreationDto.comment ?? storageOutput.Comment;
        storageOutput.AddedTime = outputForCreationDto.addedTime ?? storageOutput.AddedTime;
    }

    public OutputDto MapToOutputDto(Output output)
    {
        return new OutputDto(
            output.Id,
            output.Summa,
            output.Category,
            output.Comment,
            output.AddedTime);
    }
}

