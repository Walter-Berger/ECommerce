namespace BookService.API.Features.LoanBook;

public class LoanBookCmdHandler : IRequestHandler<LoanBookCmd, Unit>
{
    private readonly IRepository<Book> _bookRepository;

    public LoanBookCmdHandler(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(LoanBookCmd request, CancellationToken cancellationToken)
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

        book.Loan();
        await _bookRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
