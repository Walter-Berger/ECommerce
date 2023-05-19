namespace BookService.API.Features.GetBook;

public record GetBookQry(Guid Id) : IRequest<GetBookQryResult>;
