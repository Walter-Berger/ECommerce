namespace AccountService.Features.CreateUser;

public record CreateUserCmd(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    DateOnly BirthDate) : IRequest<Unit>;
