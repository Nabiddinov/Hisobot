using Report.Application.DTO.Output;
using Report.Domain.Entities;

namespace Report.Application.Service.Outputs;

public interface IOutputFactory
{
    OutputDto MapToOutputDto(Output output);
    Output MapToOutput(OutputForCreationDto outputForCreationDto, Guid userId);
    void MapToOutput(Output storageOutput, OutputForModificationDto outputForCreationDto);
}
