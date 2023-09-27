using FluentValidation;
using Report.Application.DTO.Users;

namespace Report.Application.Validation.Users;

public class UserForCreationDtoValidator : AbstractValidator<UserForCreationDto>
{
    public UserForCreationDtoValidator()
    {
        RuleFor(user => user)
            .NotNull();

        RuleFor(user => user.familyName)
            .MaximumLength(20)
            .NotEmpty();

        RuleFor(user => user.email)
            .MaximumLength(100)
            .EmailAddress()
            .NotEmpty();
    }
}