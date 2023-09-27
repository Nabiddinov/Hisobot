using FluentValidation;
using Report.Application.DTO.Input;

namespace Report.Application.Validation.Inputs;

public class InputForModificationDtoValidation : AbstractValidator<InputForModificationDto>
{
    public InputForModificationDtoValidation()
    {
        RuleFor(input => input)
            .NotNull();

       

    }
}
