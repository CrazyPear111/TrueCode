using FluentAssertions;
using Moq;
using TrueCode.CurrencyService.Currencies;
using TrueCode.CurrencyService.UseCases.Interfaces;

namespace TrueCode.CurrencyService.UseCases.UnitTests;

public class AddFavoriteUseCaseTests : TestBase
{
    [Fact]
    public async Task Invoke_ValidData_Ok()
    {
        //Arrange
        User user = new(UserId);
        Currency currency = new(CurrencyId, Name, Rate);

        var currencyContextMock = new Mock<ICurrencyContext>();

        var currencyRepositoryMock = new Mock<ICurrencyRepository>();
        _ = currencyRepositoryMock
            .Setup(r => r.GetCurrency(CurrencyId))
            .Returns(Task.FromResult(currency)!);

        var userRepositoryMock = new Mock<IUserRepository>();
        _ = userRepositoryMock
            .Setup(r => r.GetUserOrDefault(UserId))
            .Returns(Task.FromResult(user)!);

        AddFavoriteUseCase uc = new(currencyContextMock.Object, userRepositoryMock.Object, currencyRepositoryMock.Object);

        //Act
        await uc.Invoke(UserId, CurrencyId);

        //Assert
        userRepositoryMock.Verify(r => r.GetUserOrDefault(UserId));
        currencyRepositoryMock.Verify(r => r.GetCurrency(CurrencyId));
        currencyContextMock.Verify(r => r.SaveChangesAsync());
        user.FavoriteCurrencies.Should().HaveCount(1);
        var first = user.FavoriteCurrencies.First();
        first.Id.Should().Be(CurrencyId);
        first.Name.Should().Be(Name);
        first.Rate.Should().Be(Rate);
    }
}
