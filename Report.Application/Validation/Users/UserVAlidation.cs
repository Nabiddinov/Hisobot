using FluentValidation;
using Report.Domain.Entities;

namespace Report.Application.Validation.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user)
            .NotEmpty();
    }
}
