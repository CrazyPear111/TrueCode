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

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserModel model)
        {
            await _registerUseCase.Invoke(model.UserName, model.Password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserModel model)
        {
            var token = await _loginUseCase.Invoke(model.UserName, model.Password);
            return Ok(token);
        }
    }
}
