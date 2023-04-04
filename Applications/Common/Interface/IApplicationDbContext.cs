using Domain.Entities.BloodRegister;
using Domain.Entities.Media;
using Domain.Entities.Posts;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Applications.Common.Interface;

public interface IApplicationDbContext
{
   // public DbSet<ApplicationUser> Users { get; set; }
     DbSet<Hospital> Hospitals { get;  }
     DbSet<Image> Images { get;}
     DbSet<Domain.Entities.BloodRegister.BloodGroup> BloodGroups { get;  }
     DbSet<Register> Registers { get;  }
     DbSet<Blog> Blogs { get; }
     DbSet<Event> Events { get; }
     DbSet<Charity> Charities { get; }
     DbSet<ApplicationUser> Users { get;  }
     Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}