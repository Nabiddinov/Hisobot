using Report.Application.DTO.Input;
using Report.Infrastructure.Repository.Inputs;

namespace Report.Application.Service.Inputs;

public partial class InputService : IInputService
{
    private readonly IInputRepository inputRepository;
    private readonly IInputFactory inputFactory;

    public InputService(
        IInputRepository inputRepository,
        IInputFactory inputFactory)
    {
        this.inputRepository = inputRepository;
        this.inputFactory = inputFactory;
    }
    public async ValueTask<InputDto> CreateInputAsync(
        InputForCreationDto inputForCreationDto, Guid userId)
    {
        ValidateInputForCreationDto(inputForCreationDto);

        var newInput = this.inputFactory
            .MapToInput(inputForCreationDto, userId);

        var addedInput = await this.inputRepository
            .InsertAsync(newInput);

        return this.inputFactory.MapToInputDto(addedInput);
    }

    public async ValueTask<InputDto> ModifyInputAsync(InputForModificationDto inputForModificationDto)
    {
        ValidateInputForModificationDto(inputForModificationDto);

        var storageInput = await this.inputRepository
            .SelectByIdAsync(inputForModificationDto.id);

        ValidateStorageInput(storageInput, inputForModificationDto.id);

        this.inputFactory.MapToInput(storageInput, inputForModificationDto);

        var modifiedInput = await this.inputRepository
           .UpdateAsync(storageInput);

        return this.inputFactory.MapToInputDto(modifiedInput);

    }

    public async ValueTask<InputDto> RemoveInputAsync(Guid inputId)
    {
        var storageInput = await this.inputRepository
            .SelectByIdAsync(inputId);

        ValidateStorageInput(storageInput, inputId);

        var removedInput = await this.inputRepository
            .DeleteAsync(storageInput);

        return this.inputFactory.MapToInputDto(removedInput);

    }

    public double  MonthlySumAsync(Guid userId, DateTime date)
    {
        var inputs = this.inputRepository.SelectAll(input =>
                       input.AddedTime.Month == date.Month &&
                       input.AddedTime.Year == date.Year &&
                       input.UserId == userId)
            .Sum(input=>input.Summa);

        return inputs;
    }

    public IQueryable<InputDto> RetrieveInputByDate(Guid userId, DateTime date)
    {
        var inputs = this.inputRepository.SelectAll(input =>
                       input.AddedTime.Month == date.Month &&
                       input.AddedTime.Year == date.Year &&
                       input.UserId == userId);

        return inputs.Select(intput =>
                        this.inputFactory.MapToInputDto(intput)
                        );
    }
}
