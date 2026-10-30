using Enhanzer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Enhanzer.Infrastructure.Database;

public class DatabaseContext(DbContextOptions<DatabaseContext> options): DbContext(options)
{
  public DbSet<LocationDetails> LocationDetails { get; set; }
}