using TrueCode.Gateway.UseCases.Interfaces;

namespace TrueCode.Gateway.UserClient;

internal class AuthRepository : IAuthRepository
{
    private readonly Auth.Auth.AuthClient _authClient;

    public AuthRepository(Auth.Auth.AuthClient authClient)
    {
        _authClient = authClient;
    }

    public async Task RegisterAsync(string userName, string password)
    {
        await _authClient.RegisterAsync(new() { Username = userName, Password = password });
    }

    public async Task<string> LoginAsync(string userName, string password)
    {
        var result = await _authClient.LoginAsync(new() { Username = userName, Password = password });
        if (result.Success)
        {
            return result.AccessToken;
        }

        return null;
    }
}
