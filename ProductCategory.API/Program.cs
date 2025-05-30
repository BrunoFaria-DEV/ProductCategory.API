using Microsoft.EntityFrameworkCore;
using ProductCategory.API.Configurations;
using ProductCategory.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Injectable();

builder.Services.AddOpenApi();

// Add Context Configuration
builder.Services.AddDbContext<ApplicationContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();