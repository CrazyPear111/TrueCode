using Grpc.Core;
using TrueCode.CurrencyService.Api;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.Api.Services
{
    public class CurrencyService : Currency.CurrencyBase
    {
        private readonly IUseCase<long, Task<Dictionary<string, double>>> _useCase;

        public CurrencyService(IUseCase<long, Task<Dictionary<string, double>>> useCase)
        {
            _useCase = useCase;
        }

        public override async Task<CurrencyRateResponse> GetFavoritesRate(UserRequest request, ServerCallContext context)
        {
            var result = await _useCase.Invoke(request.Id);

            CurrencyRateResponse response = new();
            response.Rates.AddRange(
                result.Select(pair => new CurrencyRate() 
                { 
                    Name = pair.Key, 
                    Rate = pair.Value 
                }));

            return response;
        }
    }
}
