using Hexagonal;
using Hexagonal.Adapter.Out.Persistance;
using Hexagonal.Application.Domain.Service;
using Hexagonal.Application.Port.In;
using Hexagonal.Application.Port.Out;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarPersistancePort, CarPersistanceAdapter>();
builder.Services.AddScoped<ICarServiceUseCase, CarService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
