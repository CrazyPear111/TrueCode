namespace TrueCode.CurrencyService.Models;

public record CurrencyModel
{
    public int NumCode { get; init; }

    public string CharCode { get; init; }

    public string Name { get; init; }

    public decimal Rate { get; init; }
}
