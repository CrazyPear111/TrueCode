using TrueCode.Gateway.UseCases.Interfaces;

namespace TrueCode.Gateway.UseCases;

public class GetCurrencyRateUseCase
{
    ICurrencyRepository _repository;

    public GetCurrencyRateUseCase(ICurrencyRepository currencyRepository)
    {
        _repository = currencyRepository;
    }

    public async Task<IDictionary<string, decimal>> Invoke(Guid userId)
    {
        return await _repository.GetFavoritesRate(userId);
    }
}
