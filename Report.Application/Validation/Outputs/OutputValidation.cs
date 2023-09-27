using FluentValidation;
using Report.Domain.Entities;

namespace Report.Application.Validation.Outputs;

public class OutputValidation:AbstractValidator<Output>
{
    public OutputValidation()
    {
        RuleFor(output => output)
             .NotEmpty();
    }
}
