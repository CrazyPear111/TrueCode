namespace TrueCode.CurrencyService.Currencies;

public class User
{
    private readonly List<Currency> _favoriteCurrencies;

    private User() {}

    public User(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(userId));
        }

        Id = userId;
        _favoriteCurrencies = [];
    }

    public Guid Id { get; init; }

    public IReadOnlyCollection<Currency> FavoriteCurrencies => _favoriteCurrencies;

    public void AddCurrency(Currency currency)
    {
        ArgumentNullException.ThrowIfNull(currency, nameof(currency));
        _favoriteCurrencies.Add(currency);
    }
}
