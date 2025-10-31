using ApplicationService.Interfaces;
using ApplicationService.Services;
using DAL.Context;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ApplicationService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<GymDbContext>(_ => new GymDbContext(new DbContextOptions<GymDbContext>()));

// 🔹 Dependency Injection (DI)
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonService, PersonService>();

// 🔹 AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 🔹 MemoryCache
builder.Services.AddMemoryCache();
// 🔹 Swagger & Controller
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IJwtService, JwtService>();


// 🔹 Build app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
