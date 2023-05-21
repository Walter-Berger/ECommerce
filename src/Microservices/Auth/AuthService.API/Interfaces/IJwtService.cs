namespace AuthService.API.Interfaces;

public interface IJwtService
{
    string GenerateAccessToken(IdentityUser user);
}
