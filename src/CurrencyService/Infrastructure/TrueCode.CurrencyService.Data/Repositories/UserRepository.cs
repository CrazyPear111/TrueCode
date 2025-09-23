using Microsoft.EntityFrameworkCore;
using TrueCode.CurrencyService.Currencies;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.Data.Repositories;

internal class UserRepository(CurrencyContext context) : IUserRepository
{
    /// <summary>
    /// Fast query to get favorites rate.
    /// No tracking!
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Dictionary with key: currency name, and value: currency rate </returns>
    public async Task<Dictionary<string, decimal>> GetFavoritesRate(Guid userId)
    {
        return await context.Users
            .Where(u => u.Id == userId)
            .Include(u => u.FavoriteCurrencies)
            .SelectMany(u => u.FavoriteCurrencies)
            .AsNoTracking()
            .ToDictionaryAsync(c => c.Name, c => c.Rate);
    }

    /// <summary>
    /// Gets tracking User, with ability to change it. 
    /// Throws an exception if userId not found in database.
    /// </summary>
    /// <exception cref="InvalidOperationException">Throws if userId not found in database.</exception>
    /// <param name="userId"></param>
    /// <returns>The single User</returns>
    public async Task<User> GetUser(Guid userId)
    {
        return await GetUserOrDefault(userId) 
            ?? throw new InvalidOperationException($"User with id '{userId}' not found in database.");
    }

    /// <summary>
    /// Gets tracking User, with ability to change it. 
    /// Returns null if userId not found in database.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>The single User or null</returns>
    public async Task<User?> GetUserOrDefault(Guid userId)
    {
        return await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.FavoriteCurrencies)
                .SingleOrDefaultAsync();
    }
}
