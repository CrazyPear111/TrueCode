using FluentAssertions;
using System.Xml.Linq;

namespace TrueCode.CurrencyService.Currencies.UnitTests;

public class CurrencyTests : TestBase
{
    [Fact]
    public void Constructor_ValidData_Ok()
    {
        //Arrange

        //Act
        Currency currency = new(CurrencyId, Name, Rate);

        //Assert
        currency.Id.Should().Be(CurrencyId);
        currency.Name.Should().Be(Name);
        currency.Rate.Should().Be(Rate);
    }

    [Theory]
    [InlineData(null!)]
    [InlineData("")]
    public void Constructor_NameNullOrEmpty_ArgumentException(string? name)
    {
        //Arrange

        //Act
        Action act = () => new Currency(CurrencyId, name!, Rate);

        //Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Constructor_RateNullOrEmpty_ArgumentOutOfRangeException(decimal rate)
    {
        //Arrange

        //Act
        Action act = () => new Currency(CurrencyId, Name, rate);

        //Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void SetName_ValidData_Ok()
    {
        //Arrange
        var newName = "new name";
        Currency currency = new(CurrencyId, Name, Rate);

        //Act
        currency.Name = newName;

        //Assert
        currency.Name.Should().Be(newName);
        currency.Name.Should().NotBe(Name);
    }

    [Theory]
    [InlineData(null!)]
    [InlineData("")]
    public void SetName_NullOrEmpty_ArgumentException(string? name)
    {
        //Arrange
        Currency currency = new(CurrencyId, Name, Rate);

        //Act
        Action act = () => currency.Name = name;

        //Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void SetRate_ValidData_Ok()
    {
        //Arrange
        var newRate = 0.01m;
        Currency currency = new(CurrencyId, Name, Rate);

        //Act
        currency.Rate = newRate;

        //Assert
        currency.Rate.Should().Be(newRate);
        currency.Rate.Should().NotBe(Rate);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void SetRate_NullOrEmpty_ArgumentOutOfRangeException(decimal rate)
    {
        //Arrange
        Currency currency = new(CurrencyId, Name, Rate);

        //Act
        Action act = () => currency.Rate = rate;

        //Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}
