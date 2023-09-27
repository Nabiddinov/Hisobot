using Report.Application.DTO.Users;
using Report.Application.Validation.Users;
using Report.Domain.Entities;
using Report.Domain.Exceptions;
using System.Text.Json;

namespace Report.Application.Service.Users;

public partial class UserService
{
    public void ValidateStorageUser(User storageUser, Guid userId)
    {
        if (storageUser is null)
        {
            throw new NotFoundException($"Couldn't find user with given id: {userId}");
        }
    }

    public void ValidateUserForCreationDto(
        UserForCreationDto userForCreationDto)
    {
        var validationResult = new UserForCreationDtoValidator()
            .Validate(userForCreationDto);

        ThrowValidationExceptionIfValidationIsInvalid(validationResult);
    }



    public void ValidateUserForModificationDto(
        UserForModificationDto userForModificationDto)
    {
        var validationResult = new UserForModificationDtoValidator()
            .Validate(userForModificationDto);

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
