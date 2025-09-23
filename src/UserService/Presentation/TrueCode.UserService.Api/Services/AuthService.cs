using Grpc.Core;
using Microsoft.AspNetCore.Identity;

namespace TrueCode.UserService.Api.Services;

public class AuthService : Auth.AuthBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly TokenService _tokenService;

    public AuthService(UserManager<IdentityUser> userManager, TokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public override async Task<RegisterResponse> Register(RegisterRequest request, ServerCallContext context)
    {
        var user = new IdentityUser { UserName = request.Username, Email = request.Username };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var err = string.Join("; ", result.Errors.Select(e => e.Description));
            return new RegisterResponse { Success = false, Error = err };
        }

        return new RegisterResponse { Success = true };
    }

    public override async Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null)
            return new LoginResponse { Success = false, Error = "Invalid credentials" };

        var valid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!valid)
            return new LoginResponse { Success = false, Error = "Invalid credentials" };

        var (token, expiresIn) = _tokenService.GenerateToken(user);
        return new LoginResponse
        {
            Success = true,
            AccessToken = token,
            ExpiresIn = expiresIn
        };
    }
}
