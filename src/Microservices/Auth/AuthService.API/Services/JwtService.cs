using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthService.API.Services;

public class JwtService : IJwtService
{
    private readonly byte[] _jwtKey;
    private readonly string _jwtIssuer;
    private readonly string _jwtAudience;

    public JwtService(byte[] jwtKey, string jwtIssuer, string jwtAudience)
    {
        _jwtKey = jwtKey;
        _jwtIssuer = jwtIssuer;
        _jwtAudience = jwtAudience;
    }

    public string GenerateAccessToken(IdentityUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.UserName!)
        };

        var expiryTime = DateTime.Now.AddMinutes(20);

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(_jwtKey), 
            SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: expiryTime,
            issuer: _jwtIssuer,
            audience: _jwtAudience,
            signingCredentials: signingCredentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(securityToken);
    }
}
