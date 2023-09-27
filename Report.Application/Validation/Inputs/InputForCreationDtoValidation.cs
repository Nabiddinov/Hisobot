using FluentValidation;
using Report.Application.DTO.Input;
using Report.Domain.Entities;

namespace Report.Application.Validation.Inputs;

public class InputForCreationDtoValidation : AbstractValidator<InputForCreationDto>
{
    public InputForCreationDtoValidation()
    {
        RuleFor(input => input)
            .NotNull();

        RuleFor(input => input.comment)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(input => input.summa)
            .NotEmpty();

    }
}
