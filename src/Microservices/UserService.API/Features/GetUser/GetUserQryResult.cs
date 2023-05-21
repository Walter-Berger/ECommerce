namespace AccountService.API.Features.GetUser;


public record GetUserQryResult(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    string BirthDate);