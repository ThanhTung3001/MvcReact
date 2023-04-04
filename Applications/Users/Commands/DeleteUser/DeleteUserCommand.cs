using Applications.Common.Interface;
using Applications.Common.Models;
using MediatR;

namespace Applications.Users.Commands.DeleteUser;

public class DeleteUserCommand:IRequest<Result>
{
    public string UserId { set; get; }
    
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly IIdentityService _service;

    public DeleteUserCommandHandler(IIdentityService service)
    {
        _service = service;
    }

    public Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return _service.DeleteUserAsync(request.UserId);
    }
}