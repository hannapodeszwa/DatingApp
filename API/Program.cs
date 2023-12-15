
using API.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext> (opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));      
});

//builder.Services.AddCors();
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => policy.AllowAnyHeader()
        .AllowAnyMethod().WithOrigins("https://localhost:4200"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseCors(x => x.AllowAnyHeader() .AllowAnyMethod() /*.AllowCredentials() */.WithOrigins("http://localhost:4200"));  
//app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
app.UseCors();

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();