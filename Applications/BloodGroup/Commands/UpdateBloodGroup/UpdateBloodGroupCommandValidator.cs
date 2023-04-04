using FluentValidation;

namespace Applications.BloodGroup.Commands.UpdateBloodGroup;

public class UpdateBloodCommandValidator:AbstractValidator<UpdateBloodGroupCommand>
{
    public UpdateBloodCommandValidator()
    {
        
        RuleFor(e => e.Id)
            .NotEmpty()
            .NotNull();
        RuleFor(e => e.Name)
            .NotEmpty()
            .NotNull();
        RuleFor(e => e.Description)
            .NotNull()
            .NotEmpty();
    }
}