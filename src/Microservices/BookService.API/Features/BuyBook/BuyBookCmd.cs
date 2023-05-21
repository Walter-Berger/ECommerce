namespace BookService.API.Features.BuyBook;

public record BuyBookCmd(Guid Id) : IRequest<Unit>;
