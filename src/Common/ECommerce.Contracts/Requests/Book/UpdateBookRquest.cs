namespace ECommerce.Contracts.Requests.Book;

public record UpdateBookRquest(
    string Author,
    string Title,
    double Price);
