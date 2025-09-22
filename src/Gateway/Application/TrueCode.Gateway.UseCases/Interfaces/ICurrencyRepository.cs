namespace TrueCode.Gateway.UseCases.Interfaces;

public interface ICurrencyRepository
{
    Task<Dictionary<string, decimal>> GetFavoritesRate(long userId);
}
