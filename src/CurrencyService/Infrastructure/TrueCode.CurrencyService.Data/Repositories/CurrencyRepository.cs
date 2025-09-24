using Microsoft.EntityFrameworkCore;
using TrueCode.CurrencyService.Currencies;
using TrueCode.CurrencyService.Models.Exceptions;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.Data.Repositories;

internal class CurrencyRepository(CurrencyContext context) : ICurrencyRepository
{
    public async Task<Currency> GetCurrency(int id)
    {
        return await GetCurrencyOrDefault(id) 
            ?? throw new CurrencyNotFoundException(id);
    }

    public async Task<Currency?> GetCurrencyOrDefault(int id)
    {
        return await context.Currencies
            .Where(u => u.Id == id)
            .SingleOrDefaultAsync();
    }

    public async Task<List<Currency>> GetCurrencies()
    {
        return await context.Currencies.ToListAsync();
    }
}
