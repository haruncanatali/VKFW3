using Microsoft.EntityFrameworkCore;
using VKFW3.Application.Common.Interfaces;
using VKFW3.Domain.Entities;

namespace VKFW3.Persistence.Context;

public class ApplicationContext : DbContext,IApplicationContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
                case EntityState.Deleted:
                    entry.Entity.DeletedAt = DateTime.Now;
                    break;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        base.OnModelCreating(builder);
    }
}