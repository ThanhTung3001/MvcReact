using FluentValidation;

namespace Applications.Registers.Commands.CreateRegisters;

public class CreateRegisterCommandValidator:AbstractValidator<CreateRegisterCommand>
{
    public CreateRegisterCommandValidator()
    {
        RuleFor(e => e.Ml)
            .GreaterThan(50).WithMessage("Capacity register should great then 50 ml");
            
    }
    
}