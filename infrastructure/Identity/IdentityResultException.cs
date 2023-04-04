using Applications.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace infrastructure.Identity;

public static class IdentityResultException
{
    public static Result ToApplication( this IdentityResult result)
    {
        return result.Succeeded ? Result.Success() : Result.Failure(result.Errors.Select(e => e.Description));
    }
    
}