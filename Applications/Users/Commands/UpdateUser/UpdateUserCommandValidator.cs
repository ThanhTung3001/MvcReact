using FluentValidation;
using MediatR;

namespace Applications.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(e => e.Email)
            .EmailAddress().NotEmpty();
        RuleFor(e => e.Address)
            .NotEmpty();
        RuleFor(e => e.HopitalId)
            .GreaterThanOrEqualTo(1);
        RuleFor(e => e.UserId)
            .NotEmpty();
    }
}

