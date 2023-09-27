using Report.Application.DTO.Input;
using Report.Application.DTO.Output;

namespace Report.Application.Service.Outputs;

public interface IOutputService
{
    ValueTask<OutputDto> CreateOutputAsync(OutputForCreationDto outputForCreationDto, Guid userId);
    IQueryable<OutputDto> RetrieveOutputByDate(Guid userId, DateTime date);
    double MonthlySumAsync(Guid userId, DateTime date);
    ValueTask<OutputDto> ModifyOutputAsync(OutputForModificationDto outputForModificationDto);
    ValueTask<OutputDto> RemoveOutputAsync(Guid outputId);
}
