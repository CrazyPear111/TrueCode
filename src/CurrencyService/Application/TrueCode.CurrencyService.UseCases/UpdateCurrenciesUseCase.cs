using TrueCode.CurrencyService.Currencies;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.UseCases;

public class UpdateCurrenciesUseCase
{
    private readonly ICurrencyContext _context;
    private readonly ICurrencyRepository _currencyRepository;
    private readonly ICbrClient _client;

    public UpdateCurrenciesUseCase(ICurrencyContext context, ICurrencyRepository repository, ICbrClient client)
    {
        _context = context;
        _currencyRepository = repository;
        _client = client;
    }

    public async Task Invoke()
    {
        var models = await _client.GetCurrenciesAsync();
        var currencies = await _currencyRepository.GetCurrencies();

        foreach (var model in models)
        {
            var currency = currencies.SingleOrDefault(c => c.Id == model.NumCode);
            if (currency == null)
            {
                _context.Add(new Currency(model.NumCode, model.Name, model.Rate));
                continue;
            }

            currency.Rate = model.Rate;
        }

        await _context.SaveChangesAsync();
    }
}
