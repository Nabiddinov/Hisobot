using Report.Application.DTO.Output;
using Report.Application.Validation.Outputs;
using Report.Domain.Entities;
using Report.Domain.Exceptions;
using System.Text.Json;

namespace Report.Application.Service.Outputs;

public partial class OutputService
{
    public void ValidateStorageOutput(Output storageOutput, Guid outputId)
    {
        if (storageOutput is null)
        {
            throw new NotFoundException($"Couldn't find user with given id: {outputId}");
        }
    }

    public void ValidateOutputForCreationDto(
        OutputForCreationDto outputForCreationDto)
    {
        var validationResult = new OutputForCreationDtoValidation()
            .Validate(outputForCreationDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult);
    }
     public void ValidateOutputForModificationDto(
        OutputForModificationDto outputForModificationDto)
    {
        var validationResult = new OutputFotModificationDtoValidation()
            .Validate(outputForModificationDto);

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
