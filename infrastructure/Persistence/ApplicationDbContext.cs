using System.Reflection;
using Applications.Common.Interface;
using Domain.Entities.BloodRegister;
using Domain.Entities.Media;
using Domain.Entities.Posts;
using Domain.Entities.Users;
using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace infrastructure.Persistence;

public class ApplicationDbContext:ApiAuthorizationDbContext<ApplicationUser>,IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }
    
    public DbSet<Hospital> Hospitals  => Set<Hospital>();
    public DbSet<Image> Images  => Set<Image>();
    public DbSet<BloodGroup> BloodGroups => Set<BloodGroup>();
    public DbSet<Register> Registers  => Set<Register>();
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Event> Events =>Set<Event>();
    public DbSet<Charity> Charities =>Set<Charity>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }


   
}