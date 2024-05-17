using Microsoft.EntityFrameworkCore;
using restaurant_sis3.Contexto;
using restaurant_sis3.Modelos.Servicios.Contratos;
using restaurant_sis3.Modelos.Servicios.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPromocionesService, PromocionesService>();
builder.Services.AddScoped<IProveedoresService, ProveedoresService>();


builder.Services.AddDbContext<RestaurantContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("cadena")));
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
