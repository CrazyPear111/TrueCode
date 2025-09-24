namespace TrueCode.CurrencyService.Models.Exceptions;

public class CurrencyNotFoundException : ApplicationException
{
    public CurrencyNotFoundException(int id) : base($"Currency with id '{id}' not found in database.")
    {
    }
}
