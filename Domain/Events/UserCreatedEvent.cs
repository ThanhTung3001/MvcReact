using Domain.Common;
using Domain.Entities.Users;

namespace Domain.Events;

public class UserCreatedEvent:BaseEvent
{
    public UserCreatedEvent(ApplicationUser _user)
    {
        User = _user;
    }

    public ApplicationUser User { get; }

}