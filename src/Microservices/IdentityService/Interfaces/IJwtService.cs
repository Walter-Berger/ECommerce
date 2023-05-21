namespace IdentityService.Interfaces;

public interface IJwtService
{
    string GenerateAccessToken(IdentityUser<Guid> user);
}
