using Microsoft.EntityFrameworkCore;
using prueba1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _Config = builder.Configuration;
var _cnx = _Config.GetConnectionString("DevConnection");
builder.Services.AddDbContext<CeliaContext>(options => options.UseSqlServer(_cnx));


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
