using Microsoft.AspNetCore.Mvc;
using TrueCode.Gateway.Api.Models;
using TrueCode.Gateway.UseCases;

namespace TrueCode.Gateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RegisterUseCase _registerUseCase;
        private readonly LoginUseCase _loginUseCase;

        public AccountController(
            RegisterUseCase registerUseCase, 
            LoginUseCase loginUseCase)
        {
            _registerUseCase = registerUseCase;
            _loginUseCase = loginUseCase;
        }

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="model">Username and password</param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register([FromBody] UserModel model)
        {
            await _registerUseCase.Invoke(model.UserName, model.Password);
            return Ok();
        }

        /// <summary>
        /// Login user. Returns bearer token if success.
        /// </summary>
        /// <param name="model">Username and password</param>
        /// <returns>Bearer token</returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad request</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login([FromBody] UserModel model)
        {
            var token = await _loginUseCase.Invoke(model.UserName, model.Password);
            return Ok(token);
        }
    }
}
