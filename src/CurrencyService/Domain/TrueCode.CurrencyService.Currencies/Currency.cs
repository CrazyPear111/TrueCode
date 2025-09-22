namespace TrueCode.CurrencyService.Currencies;

public sealed class Currency
{
    private decimal rate;

    public Currency(long id, string name, decimal rate)
    {
        Id = id;
        Name = name;
        Rate = rate;
    }

    public long Id { get; private init; }

    public string Name { get; private set; }

    public decimal Rate 
    { 
        get => rate; 
        set 
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(Rate), value, "Rate must be positive.");

            rate = value;
        }
    }
}
