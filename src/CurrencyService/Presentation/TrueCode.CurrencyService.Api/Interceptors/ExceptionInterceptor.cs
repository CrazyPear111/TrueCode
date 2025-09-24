using Grpc.Core;
using Grpc.Core.Interceptors;
using TrueCode.CurrencyService.Models.Exceptions;

namespace TrueCode.CurrencyService.Api.Interceptors;

public class ExceptionInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (CurrencyNotFoundException ex)
        {
            throw new RpcException(
                new(StatusCode.NotFound, ex.Message));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
