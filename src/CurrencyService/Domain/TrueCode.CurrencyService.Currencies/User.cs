namespace TrueCode.CurrencyService.Currencies;

public class User
{
    private readonly List<Currency> _favoriteCurrencies;

    private User() {}

    public User(long userId)
    {
        Id = userId;
        _favoriteCurrencies = [];
    }

    public long Id { get; init; }

    public IReadOnlyCollection<Currency> FavoriteCurrencies => _favoriteCurrencies;

    public void AddCurrency(Currency currency)
    {
        ArgumentNullException.ThrowIfNull(currency, nameof(currency));
        _favoriteCurrencies.Add(currency);
    }
}
