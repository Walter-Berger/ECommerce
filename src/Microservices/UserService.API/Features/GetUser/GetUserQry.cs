namespace AccountService.API.Features.GetUser;


public record GetUserQry(Guid Id) : IRequest<GetUserQryResult>;
