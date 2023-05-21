namespace AccountService.API.Features.DeleteUser;


public record DeleteUserCmd(Guid Id) : IRequest<Unit>;
