namespace UserService.Dto.Requests;

public record CreateUserRequest(
    string Email,
    string FirstName,
    string LastName,
    DateOnly BirthDate);

