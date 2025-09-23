namespace TrueCode.UserService.Configuration;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; init; }

    public JwtSettings JwtSettings { get; init; }
}
