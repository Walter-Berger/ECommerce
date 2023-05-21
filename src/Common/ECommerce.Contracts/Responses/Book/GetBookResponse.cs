namespace ECommerce.Contracts.Responses;

public record GetBookResponse(
    Guid Id,
    string Title,
    string Author,
    double Price,
    bool IsLoaned);