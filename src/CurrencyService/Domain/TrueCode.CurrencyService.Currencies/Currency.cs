namespace TrueCode.CurrencyService.Currencies;

internal sealed class Currency
{
    public long Id { get; private init; }

    public string Name { get; private set; }

    public double Rate { get; private set; }
}
