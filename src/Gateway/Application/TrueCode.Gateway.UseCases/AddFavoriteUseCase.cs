using TrueCode.Gateway.UseCases.Interfaces;

namespace TrueCode.Gateway.UseCases;

public class AddFavoriteUseCase
{
    private readonly ICurrencyRepository _repository;

    public AddFavoriteUseCase(ICurrencyRepository currencyRepository)
    {
        _repository = currencyRepository;
    }

    public async Task<IDictionary<string, decimal>> Invoke(long userId, int currencyId)
    {
        return await _repository.AddFavorite(userId, currencyId);
    }
}
