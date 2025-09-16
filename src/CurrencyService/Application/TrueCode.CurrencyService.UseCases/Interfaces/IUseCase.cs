namespace TrueCode.CurrencyService.UseCases.Interfaces;

public interface IUseCase<in T, out TResult>
{
    TResult Invoke(T userId);
}
