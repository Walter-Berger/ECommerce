namespace BookService.Dto.Requests;

public record CreateBookRequest(
    string Title, 
    string Author, 
    double Price);
