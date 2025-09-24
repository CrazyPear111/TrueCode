using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TrueCode.Gateway.Api.Filters;

[AttributeUsage(AttributeTargets.All)]
public class ExceptionFilterAttribute : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        if (exception is InvalidOperationException)
        {
            HandleInvalidOperationException(context);
            return;
        }
    }

    private void HandleInvalidOperationException(ExceptionContext context)
    {
        var exception = context.Exception as InvalidOperationException;

        var details = new ProblemDetails()
        {
            Status = 400,
            Title = exception.Message,
            Detail = exception.Message,
        };

        context.Result = new BadRequestObjectResult(details);
        return;
    }
}
