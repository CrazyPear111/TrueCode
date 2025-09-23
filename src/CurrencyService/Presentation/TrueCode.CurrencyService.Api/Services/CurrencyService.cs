using Grpc.Core;
using TrueCode.CurrencyService.Api;
using TrueCode.CurrencyService.UseCases;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.Api.Services
{
    public class CurrencyService : Currency.CurrencyBase
    {
        private readonly GetCurrencyRatesByUserUseCase _getCurrencyRatesUseCase;
        private readonly AddFavoriteUseCase _addFavoriteUseCase;

        public CurrencyService(
            GetCurrencyRatesByUserUseCase getCurrencyRatesUseCase,
            AddFavoriteUseCase addFavoriteUseCase)
        {
            _getCurrencyRatesUseCase = getCurrencyRatesUseCase;
            _addFavoriteUseCase = addFavoriteUseCase;
        }

        public override async Task<CurrencyRateResponse> GetFavoritesRate(UserRequest request, ServerCallContext context)
        {
            var result = await _getCurrencyRatesUseCase.Invoke(Guid.Parse(request.Id));
            return MapCurrencyRate(result);
        }

        public override async Task<CurrencyRateResponse> AddFavorite(AddFavoriteRequest request, ServerCallContext context)
        {
            await _addFavoriteUseCase.Invoke(Guid.Parse(request.UserId), request.CurrencyId); 
            var result = await _getCurrencyRatesUseCase.Invoke(Guid.Parse(request.UserId));
            return MapCurrencyRate(result);
        }

        private static CurrencyRateResponse MapCurrencyRate(Dictionary<string, decimal> currencyRates)
        {
            CurrencyRateResponse response = new();
            response.Rates.AddRange(
                currencyRates.Select(pair => new CurrencyRate()
                {
                    Name = pair.Key,
                    Rate = pair.Value.ToString(),
                }));

            return response;
        }
    }
}
