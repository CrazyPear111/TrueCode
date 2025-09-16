namespace TrueCode.UserService.Users;

internal sealed class User
{
    public long Id { get; private init; }

    public string Name { get; private set; }

    public string Password { get; private set; }
}
