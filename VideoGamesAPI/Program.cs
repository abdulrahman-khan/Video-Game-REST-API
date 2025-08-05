using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGamesAPI.Controllers.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<VideoGameDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference(); // shows Scalar UI at /scalar
    app.MapOpenApi();            // exposes /openapi if using minimal APIs
}


app.UseHttpsRedirection();

app.UseAuthorization();
    
app.MapControllers();

app.Run();
