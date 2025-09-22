using TrueCode.CurrencyService.Currencies;

namespace TrueCode.CurrencyService.UseCases.Interfaces;

public interface IUserRepository
{
    Task<Dictionary<string, decimal>> GetFavoritesRate(long userId);

    Task<User> GetUser(long userId);

    Task<User?> GetUserOrDefault(long userId);
}
