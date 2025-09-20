using Microsoft.AspNetCore.Mvc;
using TrueCode.Gateway.UseCases;

namespace TrueCode.Gateway.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        private readonly GetCurrencyRateUseCase _useCase;

        public CurrencyController(GetCurrencyRateUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(long userId)
        {
            var result = await _useCase.Invoke(userId);
            return Ok(result);
        }
    }
}
