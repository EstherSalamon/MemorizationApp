using MemorizationApp.Data.Classes;
using Microsoft.EntityFrameworkCore;

namespace MemorizationApp.Data;

public class RecitalDataContext : DbContext
{
    private readonly string _connectionString;

    public RecitalDataContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    public DbSet<Recital> Recitals { get; set; }
}