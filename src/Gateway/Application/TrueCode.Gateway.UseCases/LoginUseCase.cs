using TrueCode.Gateway.UseCases.Interfaces;

namespace TrueCode.Gateway.UseCases;

public class LoginUseCase
{
    private readonly IAuthRepository _repository;

    public LoginUseCase(IAuthRepository authRepository)
    {
        _repository = authRepository;
    }

    public async Task<string> Invoke(string userName, string password)
    {
        return await _repository.LoginAsync(userName, password);
    }
}
