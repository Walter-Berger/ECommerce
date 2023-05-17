namespace ECommerce.Contracts.Requests;

public record CreateUserRequest(
    string Email,
    string FirstName,
    string LastName,
    DateOnly BirthDate);

