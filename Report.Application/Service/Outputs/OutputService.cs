using Report.Application.DTO.Input;
using Report.Application.DTO.Output;
using Report.Domain.Entities;
using Report.Infrastructure.Repository.Outputs;

namespace Report.Application.Service.Outputs;

public partial class OutputService : IOutputService
{
    private readonly IOutputRepository outputRepository;
    private readonly IOutputFactory outputFactory;

    public OutputService(
        IOutputRepository outputRepository,
        IOutputFactory outputFactory)
    {
        this.outputRepository = outputRepository;
        this.outputFactory = outputFactory;
    }
    public async ValueTask<OutputDto> CreateOutputAsync(OutputForCreationDto outputForCreationDto, Guid userId)
    {
        ValidateOutputForCreationDto(outputForCreationDto);

        var newOutput = this.outputFactory
            .MapToOutput(outputForCreationDto, userId);

        var addedOutput = await this.outputRepository
            .InsertAsync(newOutput);

        return this.outputFactory.MapToOutputDto(addedOutput);

    }

    public async ValueTask<OutputDto> ModifyOutputAsync(OutputForModificationDto outputForModificationDto)
    {
        ValidateOutputForModificationDto(outputForModificationDto);

        var storageOutput = await this.outputRepository
            .SelectByIdAsync(outputForModificationDto.id);

        ValidateStorageOutput(storageOutput, outputForModificationDto.id);

        this.outputFactory.MapToOutput(storageOutput, outputForModificationDto);

        var modifiedOutput = await this.outputRepository
           .UpdateAsync(storageOutput);

        return this.outputFactory.MapToOutputDto(modifiedOutput);
    }

    public async ValueTask<OutputDto> RemoveOutputAsync(Guid outputId)
    {
        var storageOutput = await this.outputRepository
            .SelectByIdAsync(outputId);

        ValidateStorageOutput(storageOutput, outputId);

       var removedOutput = await this.outputRepository
            .DeleteAsync(storageOutput);

        return this.outputFactory.MapToOutputDto(removedOutput);
    }

    public IQueryable<OutputDto> RetrieveOutputByDate(Guid userId, DateTime date)
    {
        var outputs = this.outputRepository.SelectAll(output => 
                        output.AddedTime.Month == date.Month && 
                        output.AddedTime.Year == date.Year && 
                        output.UserId == userId);

        return outputs.Select(output =>
                        this.outputFactory.MapToOutputDto(output)
                        );
    }
    public double MonthlySumAsync(Guid userId, DateTime date)
    {
        var inputs = this.outputRepository.SelectAll(output =>
                       output.AddedTime.Month == date.Month &&
                       output.AddedTime.Year == date.Year &&
                       output.UserId == userId)
                       .Sum(output => output.Summa);

        return inputs;
    }
}
