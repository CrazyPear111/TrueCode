using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrueCode.Gateway.UseCases;

namespace TrueCode.Gateway.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : Controller
    {
        private readonly GetCurrencyRateUseCase _getCurrencyRateUseCase;
        private readonly AddFavoriteUseCase _addFavoriteUseCase;

        public FavoritesController(
            GetCurrencyRateUseCase getCurrencyRateUseCase,
            AddFavoriteUseCase addFavoriteUseCase)
        {
            _getCurrencyRateUseCase = getCurrencyRateUseCase;
            _addFavoriteUseCase = addFavoriteUseCase;
        }

        /// <summary>
        /// Get favorites currency list for current user
        /// </summary>
        /// <returns>Favorites currency list</returns>
        /// <response code="200">Ok</response>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dictionary<string, decimal>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            var result = await _getCurrencyRateUseCase.Invoke(UserId);
            return Ok(result);
        }

        /// <summary>
        /// Add currency to favorites list for current user
        /// </summary>
        /// <param name="id">Currency id</param>
        /// <returns>Favorites currency list</returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthorized</response>
        [HttpPatch("{currencyId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dictionary<string, decimal>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Add(int currencyId)
        {
            var result = await _addFavoriteUseCase.Invoke(UserId, currencyId);
            return Ok(result);
        }

        private Guid UserId => Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
    }
}
