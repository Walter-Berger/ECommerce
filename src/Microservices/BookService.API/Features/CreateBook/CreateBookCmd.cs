namespace BookService.API.Features.CreateBook;

public record CreateBookCmd(
    string Title,
    string Author,
    double Price) : IRequest<Unit>;
