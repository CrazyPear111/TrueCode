using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrueCode.UserService.UseCases.Interfaces;

namespace TrueCode.UserService.Data;

public class UserDbContext : IdentityDbContext, IUserDbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
        //TODO: remove on production
        Database.Migrate();
    }
}
