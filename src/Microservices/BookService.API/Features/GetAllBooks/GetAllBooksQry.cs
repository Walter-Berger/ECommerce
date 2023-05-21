namespace BookService.API.Features.GetAllBooks;

public record GetAllBooksQry() : IRequest<List<GetAllBooksQryResult>>;
