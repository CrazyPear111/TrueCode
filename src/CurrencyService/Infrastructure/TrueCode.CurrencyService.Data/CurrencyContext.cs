using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using TrueCode.CurrencyService.Configuration;
using TrueCode.CurrencyService.Currencies;
using TrueCode.CurrencyService.Data.EntityConfiguration;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.Data;

internal class CurrencyContext : DbContext, ICurrencyContext
{
    public CurrencyContext(DbContextOptions<CurrencyContext> options) : base(options)
    {
        //TODO: remove in production
        Database.Migrate();
    }

    public DbSet<Currency> Currencies { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSnakeCaseNamingConvention();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
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
