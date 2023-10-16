using Calendar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
    
    public DbSet<Domain.Models.Calendar> Calendars { get; set; }
    public DbSet<CalendarEvent> CalendarEvents { get; set; }

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