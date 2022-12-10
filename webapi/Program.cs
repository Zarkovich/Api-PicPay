using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddControllers().AddJsonOptions(opt =>
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger(c =>
{
    c.RouteTemplate = "api-docs/swagger/{documentName}/swagger.json";
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api-docs/swagger/v1/swagger.json", "v1");
    c.RoutePrefix = "api-docs";
});


DatabaseManagementService.MigrationInitialize(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
