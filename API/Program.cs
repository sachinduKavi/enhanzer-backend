using Enhanzer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Enhanzer.API.Middleware;
using Enhanzer.API.Extensions;


Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySQL(builder.Configuration.GetValue<string>("DATBASE_URL") ?? throw new InvalidOperationException("Database URL is not configured.")));
builder.Services.AddAllServices();
builder.Services.AddAutoMapper(cfg => {}, AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options => options.AddPolicy("Frontend", policy =>
  policy.WithOrigins(builder.Configuration.GetValue<string>("ORIGIN_URL") ?? throw new InvalidOperationException("Origin URL is not configured.")).AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("Frontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
