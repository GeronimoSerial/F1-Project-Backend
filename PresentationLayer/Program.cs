using System.Reflection;
using AutoMapper;
using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Services;
using DataStorageLayer.DatabaseContext;
using DataStorageLayer.Entities;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Infrastucture.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<F1DbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<iPilotService, PilotService>();
builder.Services.AddScoped<iTeamService, TeamService>();
builder.Services.AddAutoMapper(assemblies: new Assembly[] { typeof(AutoMapperProfile).Assembly });


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = scope.ServiceProvider.GetRequiredService<F1DbContext>();
}

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