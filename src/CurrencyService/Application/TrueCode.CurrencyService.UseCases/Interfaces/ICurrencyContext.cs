namespace TrueCode.CurrencyService.UseCases.Interfaces;

public interface ICurrencyContext
{
    void Add<TEntity>(TEntity entity) where TEntity : class;

    Task SaveChangesAsync();
}
