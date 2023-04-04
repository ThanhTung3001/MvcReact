using Applications.Common.Interface;
using Applications.Common.Mappings;
using AutoMapper;
using Domain.Entities.Users;
using MediatR;

namespace Applications.Users.Commands.UpdateUser;

public class UpdateUserCommand:IRequest<UpdateUserCommand>
{
    public string UserId { get; set; }
    
    public string Email { set; get; }
    
    public string FullName { get; set; }
    
    public string Avatar { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public string Address { get; set; }
    
    public int HopitalId { get; set; }
    
    public long ICCID { get; set; }
    
    
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommand>
{
    private readonly IIdentityService _identity;

    private readonly IMapper _mapper; 

    public UpdateUserCommandHandler(IIdentityService identity, IMapper mapper)
    {
        _identity = identity;
        _mapper = mapper;
    }

    public async Task<UpdateUserCommand> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _identity.Update(request);
            if (result==null)
            {
                throw new Exception($"User as Id = {request.UserId} not found");
            }

            return _mapper.Map<UpdateUserCommand>(result);
        }
        catch (Exception e)
        {

            throw;
        }
         
    }
}