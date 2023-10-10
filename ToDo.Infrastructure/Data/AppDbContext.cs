using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Models.ToDo> ToDos { get; set; }
    public DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Shadow properties
        var allEntities = modelBuilder.Model.GetEntityTypes();
        foreach (var entity in allEntities)
        {
            entity.AddProperty("CreatedDate", typeof(DateTime));
            entity.AddProperty("UpdatedDate", typeof(DateTime));
        }
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(a => a.State is EntityState.Added or EntityState.Modified);

        foreach (var entry in entries)
        {
            entry.Property("UpdateDate").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedDate").CurrentValue = DateTime.Now;
            }
        }
        return base.SaveChanges();
    }
}