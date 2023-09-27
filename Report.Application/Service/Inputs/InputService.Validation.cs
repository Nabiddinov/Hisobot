using Report.Application.DTO.Input;
using Report.Application.Validation.Inputs;
using Report.Domain.Entities;
using Report.Domain.Exceptions;
using System.Text.Json;

namespace Report.Application.Service.Inputs;

public partial class InputService
{
    public void ValidateStorageInput(Input storageInput, Guid inputId)
    {
        if (storageInput is null)
        {
            throw new NotFoundException($"Couldn't find user with given id: {inputId}");
        }
    }

    public void ValidateInputForCreationDto(
        InputForCreationDto inputForCreationDto)
    {
        var validationResult = new InputForCreationDtoValidation()
            .Validate(inputForCreationDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult);
    }

    public void ValidateInputForModificationDto(
       InputForModificationDto inputForModificationDto)
    {
        var validationResult = new InputForModificationDtoValidation()
            .Validate(inputForModificationDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult);
    }

    private static void ThrowValidationExceptionIfValidationIsInvalid(FluentValidation.Results.ValidationResult validationResult)
    {
        if (validationResult.IsValid)
        {
            return;
        }

        var errors = JsonSerializer
                .Serialize(validationResult.Errors.Select(error => new
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage,
                    AttemptedValue = error.AttemptedValue
                }));

        throw new Domain.Exceptions.ValidationException(errors);
    }
}
