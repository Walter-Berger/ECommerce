namespace UserService.API.Features.GetUser;


public record GetUserQry(Guid Id) : IRequest<GetUserQryResult>;
