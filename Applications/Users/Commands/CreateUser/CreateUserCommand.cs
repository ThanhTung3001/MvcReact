using Applications.Common.Interface;
using Applications.Common.Models;
using MediatR;

namespace Applications.Users.Commands.CreateUser;

public class CreateUserCommand:IRequest<UserCreation>
{
    public string UserName { get; init; }
    
    public string FullName { get; init; }
    
    public string Password { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserCreation>
{
    private readonly IIdentityService _identityService;


    public CreateUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<UserCreation> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      var result =await _identityService.CreateUserAsync(request.UserName, request.Password, request.FullName);
      return result.userCreation;
    }
}