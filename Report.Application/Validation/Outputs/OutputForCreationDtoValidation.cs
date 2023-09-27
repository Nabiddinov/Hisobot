using FluentValidation;
using Report.Application.DTO.Output;

namespace Report.Application.Validation.Outputs;

public class OutputForCreationDtoValidation : AbstractValidator<OutputForCreationDto>
{
    public OutputForCreationDtoValidation()
    {
        RuleFor(output => output)
            .NotEmpty();

        RuleFor(output => output.comment)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(output => output.summa)
            .NotEmpty();

    }
}
