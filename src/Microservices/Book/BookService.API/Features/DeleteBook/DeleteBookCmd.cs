namespace BookService.API.Features.DeleteBook;

public record DeleteBookCmd(Guid Id) : IRequest<Unit>;
