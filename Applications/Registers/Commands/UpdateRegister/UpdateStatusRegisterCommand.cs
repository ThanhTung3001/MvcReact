using Applications.Common.Interface;
using Applications.Common.Models;
using Domain.Enum;
using MediatR;

namespace Applications.Registers.Commands.UpdateRegister;

public class UpdateStatusRegisterCommand:IRequest<Result>
{
    public int Id { get; set; }
    public Status Status { get; set; }
}

public class UpdateStatusRegisterCommandRequestHandler : IRequestHandler<UpdateStatusRegisterCommand, Result>
{
    private IApplicationDbContext _context;

    public UpdateStatusRegisterCommandRequestHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(UpdateStatusRegisterCommand request, CancellationToken cancellationToken)
    {
        var register = await _context.Registers.FindAsync(request.Id, cancellationToken);
        if (register == null)
        {
            throw new Exception($"Register As ID = {request.Id} Not found");
        }

        register.UpdateRegisterStatus(register.Status);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}