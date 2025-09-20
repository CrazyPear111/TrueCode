namespace TrueCode.CurrencyService.Currencies;

public class User
{
    private readonly List<Currency> _favoriteCurrencies;

    public long Id { get; init; }

    public IReadOnlyCollection<Currency> FavoriteCurrencies => _favoriteCurrencies;
}
