namespace TrueCode.CurrencyService.Currencies;

public sealed class Currency : ICurrency
{
    public long Id { get; private init; }

    public string Name { get; private set; }

    public double Rate { get; private set; }
}
