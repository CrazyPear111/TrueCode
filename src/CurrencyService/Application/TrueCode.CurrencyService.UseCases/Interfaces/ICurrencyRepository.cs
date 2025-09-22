using TrueCode.CurrencyService.Currencies;

namespace TrueCode.CurrencyService.UseCases.Interfaces;

public interface ICurrencyRepository
{
    Task<Dictionary<string, decimal>> GetFavoritesRate(long userId);

    Task<User> GetUser(long userId);

    Task<List<Currency>> GetCurrencies();
}
