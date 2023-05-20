namespace BookService.API.Features.GetBook;

public class GetBookQryHandler : IRequestHandler<GetBookQry, GetBookQryResult>
{
    private readonly IRepository<Book> _bookRepository;

    public GetBookQryHandler(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GetBookQryResult> Handle(GetBookQry request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(ErrorDetails.BookNotFound);

        // check if the book is already bought currently loaned
        if (book.IsBought)
        {
            throw new NotFoundException(ErrorDetails.BookSold);
        }
        if (book.IsLoaned)
        {
            throw new NotFoundException(ErrorDetails.BookLoaned);
        }

        var result = new GetBookQryResult(
            Id: book.Id,
            Title: book.Title,
            Author: book.Author,
            Price: book.Price,
            IsLoaned: book.IsLoaned);

        return result;
    }
}
