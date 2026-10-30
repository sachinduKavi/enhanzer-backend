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

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
