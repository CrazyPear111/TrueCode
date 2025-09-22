namespace TrueCode.Gateway.UseCases.Interfaces;

public interface ICurrencyRepository
{
    Task<Dictionary<string, decimal>> GetFavoritesRate(long userId);

    Task<Dictionary<string, decimal>> AddFavorite(long userId, int currencyId);
}
