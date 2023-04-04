using Applications.BloodGroup.Commands.DeleteBloodGroup;
using FluentValidation;

namespace Applications.BloodGroup.Commands.DeleteBloodGroup;

public class DeleteBloodGroupHandleValidator:AbstractValidator<DeleteBloodGroupCommand>
{
    public DeleteBloodGroupHandleValidator()
    {
        RuleFor(e => e.id)
            .NotEmpty()
            .NotNull();
    }
}