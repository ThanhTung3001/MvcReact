using FluentValidation;

namespace Applications.Hospitals.Commands.DeleteHospital;

public class DeleteHospitalCommandValidator:AbstractValidator<DeleteHospitalCommands>
{
    public DeleteHospitalCommandValidator()
    {
        RuleFor(e => e.Id)
            .NotEmpty().WithMessage("Id not empty ")
            .NotNull().WithMessage("Id Not Null");
    }
    
}