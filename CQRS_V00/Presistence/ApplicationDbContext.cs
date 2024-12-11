using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CQRS_V00.Presistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var entiries = ChangeTracker.Entries<Employee>();

        foreach (var entiry in entiries)
        {
            if (entiry.State == EntityState.Added)
            {
                entiry.Property(e => e.Id).CurrentValue = Guid.NewGuid();
                entiry.Property(e => e.Birthday).CurrentValue = DateOnly.FromDateTime(DateTime.Today);
            }

        }

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
