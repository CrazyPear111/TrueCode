using TrueCode.CurrencyService.Currencies;

namespace TrueCode.CurrencyService.UseCases.Interfaces;

public interface ICurrencyRepository
{
    Task<Currency> GetCurrency(int id);

    Task<Currency?> GetCurrencyOrDefault(int id);

    Task<List<Currency>> GetCurrencies();
}
