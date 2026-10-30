using Enhanzer.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using DotNetEnv;
using Enhanzer.API.Middleware;
using Enhanzer.API.Extensions;


Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

MySqlConnectionStringBuilder DatabaseConne = new()
{
  ConnectionString = builder.Configuration.GetValue<string>("DATBASE_URL")
};
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(DatabaseConne.ConnectionString, ServerVersion.AutoDetect(DatabaseConne.ConnectionString)));
builder.Services.AddAllServices();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
