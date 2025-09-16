namespace TrueCode.CurrencyService.Currencies;

internal class UserFavorites
{
    public long UserId { get; private init; }

    public List<Currency> FavoriteCurrencies { get; private set; }

    public void AddFavorite(Currency currency)
    {
        FavoriteCurrencies.Add(currency);
    }
}
