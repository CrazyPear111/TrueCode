using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.UseCases;

public class AddFavoriteUseCase
{
    private readonly ICurrencyContext _context;
    private readonly IUserRepository _userRepository;
    private readonly ICurrencyRepository _currencyRepository;

    public AddFavoriteUseCase(
        ICurrencyContext context,
        IUserRepository userRepository,
        ICurrencyRepository currencyRepository)
    {
        _context = context;
        _userRepository = userRepository;
        _currencyRepository = currencyRepository;
    }

    public async Task Invoke(Guid userId, int currencyId)
    {
        var user = await _userRepository.GetUserOrDefault(userId);
        if (user == null)
        {
            user = new(userId);
            _context.Add(user);
        }

        var currency = await _currencyRepository.GetCurrency(currencyId);
        user.AddCurrency(currency);
        await _context.SaveChangesAsync();
    }
}
