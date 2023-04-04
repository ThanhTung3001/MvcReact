using System.Xml.XPath;
using Applications.Common.Interface;
using Applications.Common.Models;
using Applications.Users.Commands;
using Applications.Users.Commands.UpdateUser;
using Domain.Entities.Users;
using Domain.Exceptions;
using infrastructure.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtToken _jwtToken;
    private readonly ILogger<IdentityService> _logger;

    private readonly SignInManager<ApplicationUser> _signInManager;

    public IdentityService(UserManager<ApplicationUser> userManager, 
        RoleManager<IdentityRole> roleManager,
        ILogger<IdentityService> logger, IJwtToken jwtToken, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
        _jwtToken = jwtToken;
        _signInManager = signInManager;
    }

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

    public async Task<(Result Result, UserCreation userCreation)> CreateUserAsync(string userName, string password, string fullname)
    {
        try
        {
            var role = await _roleManager.FindByNameAsync(Role.User.ToString());
            if (role == null)
            {
                var roleCreated = await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name = Role.User.ToString()
                });
                //_logger.Log(roleCreated.Succeeded,"");
                _logger.LogInformation($"Created role as Name {Role.User.ToString()}");
            }

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                var userInfo = new ApplicationUser()
                {
                    UserName = userName,
                    FullName = fullname,
                    

                };
                var result = await _userManager.CreateAsync(userInfo, password);
                
                var userCreation = new UserCreation();
              
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userInfo,Role.User.ToString());
                    var userToken = _jwtToken.CreateToken(userInfo.UserName,userInfo.Email??"",Role.User.ToString());
                    userCreation = new UserCreation()
                    {
                        Token = userToken.Token,
                        Duration =  int.Parse(userToken.Expires),
                        RefreshToken = userToken.RefreshToken,
                        user = new UserResponseDto()
                        {
                            UserName = userInfo.UserName,
                            FullName = userInfo.FullName,
                            Birthday = userInfo.Birthday
                        }

                    };
                }
                return (result.ToApplication(),userCreation);
            }
                
            throw new DataExistException($"username {userName} exist in the system");
          
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Can't create user with username {userName}");
        }

        return  (null,null);
    }
    
    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            _logger.LogInformation($"User as id = {userId} not found can't delete");
            throw new Exception("User Not found");
           
        }
        var result = await _userManager.DeleteAsync(user);
        return result.ToApplication();
    }

    public async Task<UserCreation> Authentication(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            //return Unauthorized(new { message = "Invalid email or password" });
            throw new Exception(message:$"User has username is {username} not exist");
        }
        else
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
            {
                throw new Exception(message:$"password not valid");   
            }
            else
            {
                var role = await _userManager.GetRolesAsync(user);
                
                   
                        var token = _jwtToken.CreateToken(user.UserName, user.Email??"", role.FirstOrDefault());
                        return new UserCreation()
                        {
                            Token = token.Token,
                            RefreshToken = token.RefreshToken,
                            Duration = int.Parse(token.Expires),
                            user = new UserResponseDto()
                            {
                                UserName = user.UserName,
                                Birthday = user.Birthday,
                                FullName = user.FullName
                            }
                        };
                    
                
            }
        }
    }

    public async Task<ApplicationUser> Update(UpdateUserCommand userCommand)
    {
        var user = await _userManager.FindByIdAsync(userCommand.UserId);
        if (user!=null)
        {
            user.Birthday = userCommand.BirthDate;
            user.Avatar = userCommand.Avatar;
            user.HospitalId = userCommand.HopitalId;
            user.FullName = userCommand.FullName;
            user.ICCID = userCommand.ICCID;
            user.Email = userCommand.Email;
            user.Address = userCommand.Address;
            var result = await _userManager.UpdateAsync(user);
            return user;
        }

        return null;

    }
}