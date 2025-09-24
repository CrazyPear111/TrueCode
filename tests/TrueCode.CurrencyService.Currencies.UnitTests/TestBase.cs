namespace TrueCode.CurrencyService.Currencies.UnitTests;

public class TestBase
{
    protected const long CurrencyId = 25;
    protected const string Name = "Test Name";
    protected const decimal Rate = 58.34m;
    protected readonly Guid UserId = Guid.NewGuid();
}
