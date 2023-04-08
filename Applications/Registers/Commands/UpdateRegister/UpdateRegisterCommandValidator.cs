using FluentValidation;

namespace Applications.Registers.Commands.UpdateRegister;

public class UpdateRegisterCommandValidator:AbstractValidator<UpdateRegisterCommand>
{

    public UpdateRegisterCommandValidator()
    {
        RuleFor(e => e.Ml)
            .GreaterThan(0).WithMessage("Capacity should great than 0");
    }
}