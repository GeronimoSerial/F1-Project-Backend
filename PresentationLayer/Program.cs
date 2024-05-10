using System.Reflection;
using BusinessLogicLayer.Services;
using DataStorageLayer.DatabaseContext;
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
builder.Services.AddAutoMapper(assemblies: new Assembly[] { typeof(AutoMapperProfile).Assembly });

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