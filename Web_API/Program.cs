using Microsoft.EntityFrameworkCore;
using Web_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp",
                      builder => builder.WithOrigins("http://localhost:5173") // Asegúrate de que el puerto coincida con el de tu aplicación Vue.js
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Soa24Context>(opt =>
{
    opt.UseSqlServer("Data Source= ENRIQUE;Initial Catalog=SOA24");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
