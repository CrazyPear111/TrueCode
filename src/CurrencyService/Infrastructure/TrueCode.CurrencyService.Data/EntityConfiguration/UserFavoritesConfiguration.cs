using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrueCode.CurrencyService.Currencies;

namespace TrueCode.CurrencyService.Data.EntityConfiguration;

internal class UserFavoritesConfiguration : IEntityTypeConfiguration<UserFavorites>
{
    public void Configure(EntityTypeBuilder<UserFavorites> builder)
    {
        builder
            .HasMany(uf => uf.FavoriteCurrencies);
    }
}
