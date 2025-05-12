using B07ASPC15_StudentPortal.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StudentContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddCors(p=>{
    p.AddPolicy("B5", policy => policy.AllowAnyHeader()
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod());
    
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("B5");
app.UseAuthorization();

app.MapControllers();

app.Run();
