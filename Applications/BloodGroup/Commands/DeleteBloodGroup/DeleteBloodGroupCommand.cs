using Applications.Common.Interface;
using Applications.Exceptions;
using MediatR;

namespace Applications.BloodGroup.Commands.DeleteBloodGroup;

public record DeleteBloodGroupCommand(int id):IRequest;

public class DeleteBloodGroupCommandHandler : IRequestHandler<DeleteBloodGroupCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBloodGroupCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteBloodGroupCommand request, CancellationToken cancellationToken)
    {
        var item = await _context.BloodGroups.FindAsync(new object?[] { request.id }, cancellationToken: cancellationToken);
        if (item == null)
        {
            throw new NotFoundException();
        }
        _context.BloodGroups.Remove(item);
    //   return await _context.SaveChangesAsync(cancellationToken);
    }
}