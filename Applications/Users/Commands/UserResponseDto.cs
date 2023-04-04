using System.ComponentModel;
using Applications.Common.Mappings;
using Domain.Entities.Users;

namespace Applications.Users.Commands;

public class UserResponseDto:IMapFrom<ApplicationUser>
{
    public  string UserName { get; set; }
    
    public string FullName { get; set; }
    
    public DateTime ?Birthday { get; set; }
}

public class UserCreation
{
    public  string Token { get; set; }
    
    public int Duration { get; set; }

    public string RefreshToken { get; set; }
    
    [DisplayName("user")]
    public UserResponseDto user { get; set; }
}

