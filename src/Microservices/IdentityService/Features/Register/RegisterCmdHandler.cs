namespace IdentityService.Features.Register;

public class RegisterCmdHandler : IRequestHandler<RegisterCmd, Unit>
{
    private readonly UserManager<IdentityUser> _userManager;

    public RegisterCmdHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RegisterCmd request, CancellationToken cancellationToken)
    {
        if (!request.Password.Equals(request.ConfirmPassword))
        {
            throw new Exception(ErrorDetails.PasswordMustMatch);
        }

        var identityUser = new IdentityUser
        {
            UserName = request.UserName,
            Email = request.UserName
        };

        var identityResult = await _userManager.CreateAsync(identityUser, request.Password);
        if (!identityResult.Succeeded)
        {
            var errors = identityResult.Errors.Select(x => x.Description).Distinct();
            throw new Exception(errors.First());
        }

        return Unit.Value;
    }
}