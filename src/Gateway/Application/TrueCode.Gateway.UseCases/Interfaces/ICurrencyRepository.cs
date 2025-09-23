namespace TrueCode.Gateway.UseCases.Interfaces;

public interface ICurrencyRepository
{
    Task<Dictionary<string, decimal>> GetFavoritesRate(Guid userId);

    Task<Dictionary<string, decimal>> AddFavorite(Guid userId, int currencyId);
}
