using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrueCode.UserService.Configuration;

namespace TrueCode.UserService.Api;

public class TokenService
{
    private readonly JwtSettings _jwtSettings;

    public TokenService(AppSettings appSettings)
    {
        _jwtSettings = appSettings.JwtSettings;
    }

    public (string Token, int ExpiresIn) GenerateToken(IdentityUser user)
    {
        var expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresMinutes);
        var expiresIn = _jwtSettings.ExpiresMinutes * 60;

        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.UniqueName, user.UserName ?? string.Empty)
        ];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
        return (tokenStr, expiresIn);
    }
}
