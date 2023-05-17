namespace BookService.API.Constants.ErrorDetails;

public static class ErrorDetails
{
    // 404 errors
    public const string SecretsNotFound = "Could not read secrets from doppler.";
    public const string BookNotFound = "Book was not found in database.";
    public const string BookSold = "Book has already been sold.";
    public const string BookLoaned = "Book is currently loaned ba another user.";

    // 500 errors
    public const string CouldNotSaveChanges = "Something went wrong while saving changes in database.";
}
