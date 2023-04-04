using Applications.Common.Interface;
using MediatR;

namespace Applications.Users.Commands.ValidatorUser;

public class ValidatorUserCommand:IRequest<UserCreation>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    
}

public class ValidatorUserCommandHandlers : IRequestHandler<ValidatorUserCommand, UserCreation>
{
    private readonly IIdentityService _identity;

    public ValidatorUserCommandHandlers(IIdentityService identity)
    {
        _identity = identity;
    }

    public async Task<UserCreation> Handle(ValidatorUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _identity.Authentication(request.UserName, request.Password);
        if (result == null)
        {
            throw new Exception("Username or password not exist");
        }
        return result;
    }
}