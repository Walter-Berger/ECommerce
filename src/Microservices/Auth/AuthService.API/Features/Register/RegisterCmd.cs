namespace AuthService.API.Features.Register;

public record RegisterCmd(string UserName, string Password) : IRequest<Unit>;
