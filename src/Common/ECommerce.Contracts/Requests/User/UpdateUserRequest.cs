namespace ECommerce.Contracts.Requests;

public record UpdateUserRequest(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    DateOnly BirthDate);

