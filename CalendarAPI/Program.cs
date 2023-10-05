using CalendarAPI.Data;
using CalendarAPI.Data.Repositories;
using CalendarAPI.Data.Repositories.Interfaces;
using CalendarAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICalendarRepository, CalendarRepository>();
builder.Services.AddTransient<ICalendarEventRepository, CalendarEventRepository>();
builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<ICalendarEventService, CalendarEventService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();