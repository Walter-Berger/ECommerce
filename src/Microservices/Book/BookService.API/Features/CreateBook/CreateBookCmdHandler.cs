namespace BookService.API.Features.CreateBook;

public class CreateBookCmdHandler : IRequestHandler<CreateBookCmd, Unit>
{
    private readonly IRepository<Book> _bookRepository;

    public CreateBookCmdHandler(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(CreateBookCmd request, CancellationToken cancellationToken)
    {
        // create new book 
        var book = new Book(
            id: Guid.NewGuid(),
            title: request.Title,
            author: request.Author,
            price: request.Price
        );

        // add and save book in database
        await _bookRepository.AddAsync(book, cancellationToken);

        return Unit.Value;
    }
}
