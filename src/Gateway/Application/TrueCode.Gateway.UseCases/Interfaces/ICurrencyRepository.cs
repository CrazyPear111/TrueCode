namespace TrueCode.Gateway.UseCases.Interfaces;

public interface ICurrencyRepository
{
    Task<Dictionary<string, double>> GetFavoritesRate(long userId);
}
