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
}