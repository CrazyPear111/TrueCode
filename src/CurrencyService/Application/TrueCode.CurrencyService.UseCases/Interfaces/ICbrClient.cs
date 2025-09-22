using TrueCode.CurrencyService.Models;

namespace TrueCode.CurrencyService.UseCases.Interfaces;

public interface ICbrClient
{
    Task<IEnumerable<CurrencyModel>> GetCurrenciesAsync();
}
