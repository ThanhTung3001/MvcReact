using Applications.Common.Models;
using Applications.Users.Commands;
using Applications.Users.Commands.UpdateUser;
using Domain.Entities.Users;

namespace Applications.Common.Interface;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, UserCreation userCreation )> CreateUserAsync(string userName, string password,string fullname);

    Task<Result> DeleteUserAsync(string userId);

    Task<UserCreation> Authentication(string username,string password);

    Task<ApplicationUser> Update(UpdateUserCommand userCommand);
}