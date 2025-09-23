using TrueCode.CurrencyService.Currencies;

namespace TrueCode.CurrencyService.UseCases.Interfaces;

public interface IUserRepository
{
    Task<Dictionary<string, decimal>> GetFavoritesRate(Guid userId);

    Task<User> GetUser(Guid userId);

    Task<User?> GetUserOrDefault(Guid userId);
}
