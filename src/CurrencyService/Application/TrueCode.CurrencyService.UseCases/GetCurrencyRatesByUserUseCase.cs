using TrueCode.CurrencyService.Currencies;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.UseCases;

internal class GetCurrencyRatesByUserUseCase : IUseCase<long, Task<Dictionary<string, double>>>
{
    private ICurrencyRepository _currencyRepository;

    public GetCurrencyRatesByUserUseCase(ICurrencyRepository repository)
    {
        _currencyRepository = repository;
    }

    public async Task<Dictionary<string, double>> Invoke(long userId)
    {
        var favoritesRate = await _currencyRepository.GetFavoritesRate(userId);
        return favoritesRate;
    }
}
