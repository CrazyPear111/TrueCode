using TrueCode.CurrencyService.Currencies;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.UseCases;

public class GetCurrencyRatesByUserUseCase : IUseCase<long, Task<Dictionary<string, decimal>>>
{
    private readonly IUserRepository _userRepository;

    public GetCurrencyRatesByUserUseCase(IUserRepository repository)
    {
        _userRepository = repository;
    }

    public async Task<Dictionary<string, decimal>> Invoke(long userId)
    {
        var favoritesRate = await _userRepository.GetFavoritesRate(userId);
        return favoritesRate;
    }
}
