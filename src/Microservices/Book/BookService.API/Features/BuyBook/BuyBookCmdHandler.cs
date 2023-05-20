namespace BookService.API.Features.BuyBook;

public class BuyBookCmdHandler : IRequestHandler<BuyBookCmd, Unit>
{
    private readonly IRepository<Book> _bookRepository;

    public BuyBookCmdHandler(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Unit> Handle(BuyBookCmd request, CancellationToken cancellationToken)
    {
        // check if the requested book exists
        var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(ErrorDetails.BookNotFound);

        // check if the book is already bought or currently loaned
        if (book.IsBought)
        {
            throw new NotFoundException(ErrorDetails.BookSold);
        }
        if (book.IsLoaned)
        {
            throw new NotFoundException(ErrorDetails.BookLoaned);
        }

        // mark the book as bought
        book.Buy();

        // save changes
        await _bookRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
