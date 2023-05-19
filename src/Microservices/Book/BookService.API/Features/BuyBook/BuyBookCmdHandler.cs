namespace BookService.API.Features.BuyBook;

public class BuyBookCmdHandler : IRequestHandler<BuyBookCmd, Unit>
{
    private readonly DatabaseContext _databaseContext;

    public BuyBookCmdHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Unit> Handle(BuyBookCmd request, CancellationToken cancellationToken)
    {
        // check if the requested book exists and is not already bought
        var book = await _databaseContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(ErrorDetails.BookNotFound);

        // check if the book is already bought or loaned
        if (book.IsBought is true)
        {
            throw new NotFoundException(ErrorDetails.BookSold);
        }
        if (book.IsLoaned is true)
        {
            throw new NotFoundException(ErrorDetails.BookLoaned);
        }

        // mark the book as bought
        book.Buy();
        await _databaseContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
