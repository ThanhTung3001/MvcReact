using FluentValidation;

namespace Applications.BloodGroup.Commands.CreateBloodGroup;

public class CreateBloodGroupHandleValidator:AbstractValidator<CreateBloodGroupCommand>
{
    public CreateBloodGroupHandleValidator()
    {
        
        RuleFor(e => e.Name)
            .NotEmpty()
            .NotNull();
        RuleFor(e => e.Description)
            .NotNull()
            .NotEmpty();
    }

}