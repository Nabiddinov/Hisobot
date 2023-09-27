using FluentValidation;
using Report.Application.DTO.Input;
using Report.Application.DTO.Output;

namespace Report.Application.Validation.Outputs;

public class OutputFotModificationDtoValidation:AbstractValidator<OutputForModificationDto>
{
    public OutputFotModificationDtoValidation()
    {
        RuleFor(output => output)
            .NotEmpty();
        
    }
}
