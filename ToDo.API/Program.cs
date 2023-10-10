using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.Infrastructure;
using ToDo.API.Services;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;
using ToDo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ToDoApiConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(connectionString); });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Func<AppDbContext>>(provider => () => provider.GetService<AppDbContext>());
builder.Services.AddScoped<ToDoDbFactory>();
builder.Services.AddScoped<IToDoUnitOfWork, ToDoUnitOfWork>();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();

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