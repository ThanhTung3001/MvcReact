using Applications.Common.Interface;
using Applications.Common.Models;
using Applications.Exceptions;
using MediatR;

namespace Applications.BloodGroup.Commands.CreateBloodGroup;

public class CreateBloodGroupCommand:IRequest
{
    public string Name { get; init; }
    
    public string Description { get; init; }

    public string Summary { get; init; } = "";
}

public class CreateBloodGroupCommandHandler : IRequestHandler<CreateBloodGroupCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateBloodGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateBloodGroupCommand request, CancellationToken cancellationToken)
    {
        var bloodGroup = _context.BloodGroups.Where(e => e.Name.ToUpper().Equals(request.Name)).ToList().FirstOrDefault();
        if (bloodGroup != null)
        {
            throw new Exception($"Blood has Name is {request.Name} exist ");
        }

        var item = new Domain.Entities.BloodRegister.BloodGroup(request.Name, request.Description,request.Summary);
        _context.BloodGroups.Add(item);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
