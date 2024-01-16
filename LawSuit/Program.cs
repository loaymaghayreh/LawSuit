using LawSuit.Application.Service.Interface;
using LawSuit.Domain.Interface;
using LawSuit.Infrastructure.LawSuitDbContext;
using LawSuit.Infrastructure.Mapper;
using LawSuit.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options. UseSqlServer(builder.
    Configuration.GetConnectionString("DefaultConnection"),
    b=>b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

builder.Services.AddAutoMapper(typeof(MapperClasses)); 

builder.Services.AddTransient<IUnitOfWork, UnitOfWorkManegar>();
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
