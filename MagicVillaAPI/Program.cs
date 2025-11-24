using MagicVillaAPI;
using MagicVillaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//here we configure our 'ApplicationDbContext' to use this connection string
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection"));
});

//define automapper service to the builder 
builder.Services.AddAutoMapper(typeof(MappingConfig));

// Add services to the container.
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
