namespace TrueCode.Gateway.UseCases.Interfaces;

public interface IAuthRepository
{
    Task RegisterAsync(string userName, string password);

    Task<string> LoginAsync(string userName, string password);
}
