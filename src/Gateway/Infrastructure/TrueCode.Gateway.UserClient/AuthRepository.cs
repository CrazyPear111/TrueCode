using TrueCode.Gateway.UseCases.Interfaces;
using TrueCode.UserService.Api;

namespace TrueCode.Gateway.UserClient;

internal class AuthRepository : IAuthRepository
{
    private readonly Auth.AuthClient _authClient;

    public AuthRepository(Auth.AuthClient authClient)
    {
        _authClient = authClient;
    }

    public async Task RegisterAsync(string userName, string password)
    {
        var result = await _authClient.RegisterAsync(new() { Username = userName, Password = password });
        if (!result.Success)
        {
            throw new InvalidOperationException(result.Error);
        }
    }

    public async Task<string> LoginAsync(string userName, string password)
    {
        var result = await _authClient.LoginAsync(new() { Username = userName, Password = password });
        if (result.Success)
        {
            return result.AccessToken;
        }

        throw new InvalidOperationException(result.Error);
    }
}
