namespace BookService.API.Features.GetAllBooks;

public class GetAllBooksQryHandler : IRequestHandler<GetAllBooksQry, List<GetAllBooksQryResult>>
{
    private readonly IRepository<Book> _bookRepository;

    public GetAllBooksQryHandler(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<GetAllBooksQryResult>> Handle(GetAllBooksQry request, CancellationToken cancellationToken)
    {
        // check if there are any books in database
        var books = await _bookRepository.GetAllAsync(cancellationToken);

        var results = new List<GetAllBooksQryResult>();
        foreach (var book in books)
        {
            results.Add(new GetAllBooksQryResult(
                Id: book.Id,
                Title: book.Title,
                Author: book.Author,
                Price: book.Price,
                IsLoaned: book.IsLoaned));
        }

        // if there were no books found, return an empty list
        return results;
    }
}
