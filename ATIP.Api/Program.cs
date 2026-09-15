using System.Text.Json.Serialization;
using ATIP.Core.Interfaces;
using ATIP.Infrastructure.Services;
using ATIP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AtipDatabase")
    ?? throw new InvalidOperationException(
        "Connection string 'AtipDatabase' was not found.");

builder.Services.AddDbContext<AtipDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IChildService, ChildService>();

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "ATIP API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
