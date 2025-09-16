using TrueCode.CurrencyService.Currencies;

namespace TrueCode.CurrencyService.UseCases.Interfaces;

internal interface ICurrencyRepository
{
    Task<Dictionary<string, double>> GetFavoritesRate();
}
