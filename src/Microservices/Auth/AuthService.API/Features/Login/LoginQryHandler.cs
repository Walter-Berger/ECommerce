namespace AuthService.API.Features.Login;

public class LoginQryHandler : IRequestHandler<LoginQry, LoginQryResult>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJwtService _jwtService;

    public LoginQryHandler(UserManager<IdentityUser> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public async Task<LoginQryResult> Handle(LoginQry request, CancellationToken cancellationToken)
    {
        var identityUser = await _userManager.FindByEmailAsync(email: request.UserName)
            ?? throw new NotFoundException(ErrorDetails.UserNotFound);

        await _userManager.CheckPasswordAsync(user: identityUser, password: request.Password);

        var accessToken = _jwtService.GenerateAccessToken(identityUser);

        return new LoginQryResult(accessToken);
    }
}
