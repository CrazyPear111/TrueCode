using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrueCode.CurrencyService.Currencies;

namespace TrueCode.CurrencyService.Data.EntityConfiguration;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(uf => uf.FavoriteCurrencies)
            .WithMany()
            .UsingEntity("user_favorites");
    }
}
