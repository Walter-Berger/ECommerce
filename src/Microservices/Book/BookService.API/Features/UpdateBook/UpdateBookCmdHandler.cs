namespace BookService.API.Features.UpdateBook;

public class UpdateBookCmdHandler : IRequestHandler<UpdateBookCmd, Unit>
{
    private readonly IRepository<Book> _bookRepository;
    private readonly ITimeFactory _timeFactory;

    public UpdateBookCmdHandler(IRepository<Book> bookRepository, ITimeFactory timeFactory)
    {
        _bookRepository = bookRepository;
        _timeFactory = timeFactory;
    }

    public async Task<Unit> Handle(UpdateBookCmd request, CancellationToken cancellationToken)
    {
        // check if the requested book exists in database
        var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(ErrorDetails.BookNotFound);

        // check if the book is already bought currently loaned
        if (book.IsBought)
        {
            throw new NotFoundException(ErrorDetails.BookSold);
        }
        if (book.IsLoaned)
        {
            throw new NotFoundException(ErrorDetails.CannotUpdateLoanedBook);
        }

        // create a model of the updated version
        var updatedBook = new Book(
            id: request.Id,
            title: request.Title,
            author: request.Author,
            price: request.Price);

        // update the old book
        book.Update(updatedBook, _timeFactory.UnixTimeNow());
        await _bookRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
