using Applications.Common.Interface;
using Applications.Exceptions;
using MediatR;

namespace Applications.BloodGroup.Commands.UpdateBloodGroup;

public class UpdateBloodGroupCommand:IRequest
{
    public int Id { get; init; }
    
    public string Name { get; init; }
    
    public string Description { get; init; }
    
    public string Summary { get; init; }
}

public class UpdateBloodGroupCommandHandler : IRequestHandler<UpdateBloodGroupCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBloodGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateBloodGroupCommand request, CancellationToken cancellationToken)
    {
        var bloodGroup =await _context.BloodGroups.FindAsync(request.Id,cancellationToken);
        if (bloodGroup == null)
        {
            throw new NotFoundException(nameof(BloodGroup), request.Id);
        }

        bloodGroup.Name = request.Name;
        bloodGroup.Description = request.Name;
        bloodGroup.Summary = request.Summary;
        await _context.SaveChangesAsync(cancellationToken);
    }
}