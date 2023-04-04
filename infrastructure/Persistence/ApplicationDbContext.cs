using System.Reflection;
using Applications.Common.Interface;
using Domain.Entities.BloodRegister;
using Domain.Entities.Media;
using Domain.Entities.Posts;
using Domain.Entities.Users;
using Duende.IdentityServer.EntityFramework.Options;
using infrastructure.Interceptors;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace infrastructure.Persistence;

public class ApplicationDbContext:ApiAuthorizationDbContext<ApplicationUser>,IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions, IMediator mediator, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }
    
    public DbSet<Hospital> Hospitals  => Set<Hospital>();
    public DbSet<Image> Images  => Set<Image>();
    public DbSet<BloodGroup> BloodGroups => Set<BloodGroup>();
    public DbSet<Register> Registers  => Set<Register>();
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Event> Events =>Set<Event>();
    public DbSet<Charity> Charities =>Set<Charity>();

    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      //  await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}


   
