using TrueCode.CurrencyService.Api;
using TrueCode.Gateway.UseCases.Interfaces;

namespace TrueCode.Gateway.CurrencyClient;

internal class CurrencyRepository : ICurrencyRepository
{
    private readonly Currency.CurrencyClient _currencyClient;

    public CurrencyRepository(Currency.CurrencyClient currencyClient)
    {
        _currencyClient = currencyClient;
    }

    public async Task<Dictionary<string, decimal>> GetFavoritesRate(long userId)
    {
        var response = await _currencyClient.GetFavoritesRateAsync(new() { Id = userId });
        return response.Rates.ToDictionary(r => r.Name, r => decimal.Parse(r.Rate));
    }
}
