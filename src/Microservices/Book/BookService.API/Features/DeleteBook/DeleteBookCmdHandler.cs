namespace BookService.API.Features.DeleteBook;

public class DeleteBookCmdHandler : IRequestHandler<DeleteBookCmd, Unit>
{
    private readonly IRepository<Book> _bookRepository;

    public DeleteBookCmdHandler(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(DeleteBookCmd request, CancellationToken cancellationToken)
    {
        // check if book exists
        var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(ErrorDetails.BookNotFound);

        // check if the book is already bought currently loaned
        if (book.IsBought)
        {
            throw new NotFoundException(ErrorDetails.BookNotFound);
        }
        if (book.IsLoaned)
        {
            throw new DatabaseException(ErrorDetails.CannotDeleteLoanedBook);
        }

        // remove book from database
        await _bookRepository.DeleteAsync(book, cancellationToken);

        return Unit.Value;
    }
}
