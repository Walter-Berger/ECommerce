namespace BookService.API.Features.LoanBook;

public record LoanBookCmd(Guid Id) : IRequest<Unit>;
