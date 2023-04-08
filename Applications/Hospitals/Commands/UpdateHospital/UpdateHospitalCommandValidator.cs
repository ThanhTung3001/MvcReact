using FluentValidation;

namespace Applications.Hospitals.Commands.UpdateHospital;

public class UpdateHospitalCommandValidator:AbstractValidator<UpdateHospitalCommands>
{
    public UpdateHospitalCommandValidator()
    {
        RuleFor(e=>e.Id)
            .NotEmpty().WithMessage("Id is not empty")
            .NotNull().WithMessage("Id is not null");
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("HospitalName is not empty")
            .NotNull().WithMessage("HospitalName is not null");
        RuleFor(e=>e.Address)
            .NotEmpty().WithMessage("Address is not empty")
            .NotNull().WithMessage("Address is not null");
    }
}