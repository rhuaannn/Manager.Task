using Manager.Task.Domain.Task;
using Manager.Task.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Manager.Task.Infra.Context;

public class DbContextApi : DbContext
{
    public DbContextApi(DbContextOptions<DbContextApi> options) : base(options) { }

    public DbSet<ManagerTask> ManagerTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ManagerTask>()
            .OwnsOne(mt => mt.Description);

        modelBuilder.Entity<ManagerTask>()
            .OwnsOne(t => t.Title);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextApi).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}