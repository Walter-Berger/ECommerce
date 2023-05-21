namespace IdentityService.Features.Login;

public class LoginQryHandler : IRequestHandler<LoginQry, LoginQryResult>
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;
    private readonly IJwtService _jwtService;

    public LoginQryHandler(UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtService = jwtService;
    }

    public async Task<LoginQryResult> Handle(LoginQry request, CancellationToken cancellationToken)
    {
        // check if email exists
        var identityUser = await _userManager.FindByEmailAsync(email: request.UserName)
            ?? throw new NotFoundException(ErrorDetails.LoginFailed);

        // check if password matches with user
        _ = await _signInManager.CheckPasswordSignInAsync(user: identityUser, password: request.Password, false)
            ?? throw new NotFoundException(ErrorDetails.LoginFailed);

        // generate access token
        var accessToken = _jwtService.GenerateAccessToken(identityUser);
        return new LoginQryResult(accessToken);
    }
}
