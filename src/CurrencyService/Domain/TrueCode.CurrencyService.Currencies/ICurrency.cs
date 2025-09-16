namespace TrueCode.CurrencyService.Currencies;

public interface ICurrency
{
    long Id { get; }

    string Name { get; }

    double Rate { get; }
}