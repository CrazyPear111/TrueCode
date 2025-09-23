using TrueCode.Gateway.UseCases.Interfaces;

namespace TrueCode.Gateway.UseCases;

public class RegisterUseCase
{
    private readonly IAuthRepository _repository;

    public RegisterUseCase(IAuthRepository authRepository)
    {
        _repository = authRepository;
    }

    public async Task Invoke(string userName, string password)
    {
        await _repository.RegisterAsync(userName, password);
    }
}
