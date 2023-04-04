using Applications.Common.Interface;
using Domain.Entities.Users;
using infrastructure.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace infrastructure.Persistence;

public class AppDbContextInitializer
{
    private readonly ILogger<AppDbContextInitializer> _logger;

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly ApplicationDbContext _context;
    
    public AppDbContextInitializer(ILogger<AppDbContextInitializer> logger, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    public async Task Initializer()
    {
        try
        {
            if (_context.Database.IsSqlServer()) {

                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex) {

            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task Send()
    {
        try
        {
            await TrySend();
        }
        catch (Exception e)
        {
           _logger.LogError(e,"An Error when sending the database");
            throw;
        }
    }

    public async Task TrySend()
    {
        var adminRole = new IdentityRole(Role.Administration.ToString()); // create role if not exist
        if (_roleManager.Roles.All(e => e.Name != adminRole.Name)) {
            await _roleManager.CreateAsync(adminRole);
        }
        var administrator = new ApplicationUser { UserName = "Administrator@localhost", Email = "Administrator@localhost",FullName="Admin" };
        if (_userManager.Users.All(e => e.UserName != administrator.UserName)) { // create user name as role if not exist
            await _userManager.CreateAsync(administrator);
            if (!string.IsNullOrEmpty(administrator.UserName)) {
                await _userManager.AddToRoleAsync(administrator,adminRole.Name!);
            }
        }
    }
}