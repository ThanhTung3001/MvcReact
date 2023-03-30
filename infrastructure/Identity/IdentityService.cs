using Applications.Common.Interface;
using Applications.Common.Models;

namespace infrastructure.Identity;

public class IdentityService:IIdentityService
{
    public Task<string?> GetUserNameAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsInRoleAsync(string userId, string role)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        throw new NotImplementedException();
    }

    public Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteUserAsync(string userId)
    {
        throw new NotImplementedException();
    }
}