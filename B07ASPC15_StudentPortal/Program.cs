using B07ASPC15_StudentPortal.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

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
builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
    options.OutputFormatters.Add(new SystemTextJsonOutputFormatter
            (new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                //ContractResolver=new CamelCasePropertyNamesContractResolver()
                PropertyNameCaseInsensitive = false,
                PropertyNamingPolicy = null,
                WriteIndented = true,
                TypeInfoResolver = JsonSerializerOptions.Default.TypeInfoResolver,
            }));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("B5");
app.UseAuthorization();

app.MapControllers();

app.Run();
