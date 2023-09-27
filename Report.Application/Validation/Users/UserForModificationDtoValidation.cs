using FluentValidation;
using Report.Application.DTO.Users;

namespace Report.Application.Validation.Users;

public class UserForModificationDtoValidator : AbstractValidator<UserForModificationDto>
{
    public UserForModificationDtoValidator()
    {
        RuleFor(user => user)
            .NotNull();
    }
}
