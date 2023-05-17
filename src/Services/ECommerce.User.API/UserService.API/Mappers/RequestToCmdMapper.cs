namespace UserService.API.Mappers;

public static class RequestToCmdMapper
{
    public static CreateUserCmd ToCommand(this CreateUserRequest request)
    {
        var result = new CreateUserCmd(
            Email: request.Email,
            FirstName: request.FirstName,
            LastName: request.LastName,
            BirthDate: request.BirthDate
        );
        return result;
    }

    public static UpdateUserCmd ToCommand(this UpdateUserRequest request, Guid id)
    {
        var result = new UpdateUserCmd(
            Id: id,
            Email: request.Email,
            FirstName: request.FirstName,
            LastName: request.LastName,
            BirthDate: request.BirthDate
        );
        return result;
    }
}
