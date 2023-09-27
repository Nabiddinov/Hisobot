using FluentValidation;
using Report.Domain.Entities;

namespace Report.Application.Validation.Inputs;

public class InputValidation : AbstractValidator<Input>
{
    public InputValidation()
    {
        RuleFor(input => input)
            .NotEmpty();        
    }
}
