using FluentAssertions;

namespace TrueCode.CurrencyService.Currencies.UnitTests;

public class UserTests : TestBase
{
    [Fact]
    public void Constructor_ValidData_Ok()
    {
        //Arrange

        //Act
        User user = new(UserId);

        //Assert
        user.Id.Should().Be(UserId);
        user.FavoriteCurrencies.Should().BeEmpty();
    }

    [Fact]
    public void Constructor_EmptyId_ArgumentException()
    {
        //Arrange

        //Act
        Action act = () => new User(Guid.Empty);

        //Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddCurrency_ValidData_Ok()
    {
        //Arrange
        var newId = 87;
        var newName = "new name";
        var newRate = 11.11m;

        User user = new(UserId);
        Currency currency = new(CurrencyId, Name, Rate);
        Currency currency2 = new(newId, newName, newRate);

        //Act
        user.AddCurrency(currency);
        user.AddCurrency(currency2);

        //Assert
        user.Id.Should().Be(UserId);
        user.FavoriteCurrencies.Should().HaveCount(2);
        var first = user.FavoriteCurrencies.First();
        var last = user.FavoriteCurrencies.Last();
        first.Should().NotBeNull();
        first.Id.Should().Be(CurrencyId);
        first.Name.Should().Be(Name);
        first.Rate.Should().Be(Rate);
        last.Should().NotBeNull();
        last.Id.Should().Be(newId);
        last.Name.Should().Be(newName);
        last.Rate.Should().Be(newRate);
    }

    [Fact]
    public void AddCurrency_Null_ArgumentNullException()
    {
        //Arrange
        User user = new(UserId);

        //Act
        Action act = () => user.AddCurrency(null!);

        //Assert
        act.Should().Throw<ArgumentException>();
        user.FavoriteCurrencies.Should().BeEmpty();
    }
}
