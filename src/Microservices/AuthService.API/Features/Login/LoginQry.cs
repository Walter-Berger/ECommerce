namespace AuthService.API.Features.Login;

public record LoginQry(string UserName, string Password) : IRequest<LoginQryResult>;
