using ATIP.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATIP.Infrastructure.Data;

public class AtipDbContext : DbContext
{
    public AtipDbContext(DbContextOptions<AtipDbContext> options)
        : base(options)
    {
    }

    public DbSet<Child> Children => Set<Child>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AtipDbContext).Assembly);
    }

}