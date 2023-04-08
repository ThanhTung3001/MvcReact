using FluentValidation;

namespace Applications.Hospitals.Commands.CreateHospital;

public class CreateHospitalCommandValidator:AbstractValidator<CreateHospitalCommands>
{
    public CreateHospitalCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("HospitalName is not empty")
            .NotNull().WithMessage("HospitalName is not null");
        RuleFor(e=>e.Address)
            .NotEmpty().WithMessage("Address is not empty")
            .NotNull().WithMessage("Address is not null");
    }
    
}