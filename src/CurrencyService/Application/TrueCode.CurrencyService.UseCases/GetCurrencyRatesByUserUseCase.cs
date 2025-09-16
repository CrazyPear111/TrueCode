using TrueCode.CurrencyService.Currencies;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.UseCases;

internal class GetCurrencyRatesByUserUseCase : IUseCase<long, Task<Dictionary<string, double>>>
{
    private ICurrencyRepository currencyRepository;

    public async Task<Dictionary<string, double>> Invoke(long userId)
    {
        var favoritesRate = await currencyRepository.GetFavoritesRate(userId);
        return favoritesRate;
    }
}
