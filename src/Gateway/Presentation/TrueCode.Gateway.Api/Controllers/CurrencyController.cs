using Microsoft.AspNetCore.Mvc;
using TrueCode.Gateway.UseCases;

namespace TrueCode.Gateway.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : Controller
    {
        private readonly GetCurrencyRateUseCase _getCurrencyRateUseCase;
        private readonly AddFavoriteUseCase _addFavoriteUseCase;

        public CurrencyController(
            GetCurrencyRateUseCase getCurrencyRateUseCase,
            AddFavoriteUseCase addFavoriteUseCase)
        {
            _getCurrencyRateUseCase = getCurrencyRateUseCase;
            _addFavoriteUseCase = addFavoriteUseCase;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(long userId)
        {
            var result = await _getCurrencyRateUseCase.Invoke(userId);
            return Ok(result);
        }

        [HttpPatch("{userId}/favorites/{currencyId}")]
        public async Task<IActionResult> Patch(long userId, int currencyId)
        {
            var result = await _addFavoriteUseCase.Invoke(userId, currencyId);
            return Ok(result);
        }
    }
}
