using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TrueCode.CurrencyService.Currencies;
using TrueCode.CurrencyService.Data.EntityConfiguration;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.Data;

internal class CurrencyContext : DbContext, ICurrencyContext
{
    private readonly string _connectionString;

    public CurrencyContext()
    {
    }

    public DbSet<Currency> Currencies { get; set; }

    public DbSet<UserFavorites> UserFavorites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_connectionString)
            .UseSnakeCaseNamingConvention();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
        modelBuilder.ApplyConfiguration(new UserFavoritesConfiguration());
    }

    public void Add<TEntity>(TEntity entity) where TEntity : class
    {
        base.Add(entity);
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            await base.SaveChangesAsync();
        }
        catch (DbException)
        {
            //TODO: log exception
            throw;
        }
    }
}
