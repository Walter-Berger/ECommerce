namespace UserService.API.Mappers;

public static class ResultToResponseMapper
{
    public static GetUserResponse ToResponse(this GetUserQryResult result)
    {
        var response = new GetUserResponse(
            Id: result.Id,
            Email: result.Email,
            FirstName: result.FirstName,
            LastName: result.LastName,
            BirthDate: result.BirthDate);

        return response;
    }

    public static List<GetUserResponse> ToResponse(this List<GetAllUsersQryResult> results)
    {
        var response = new List<GetUserResponse>();
        foreach (var result in results)
        {
            response.Add(new GetUserResponse(
                Id: result.Id,
                Email: result.Email,
                FirstName: result.FirstName,
                LastName: result.LastName,
                BirthDate: result.BirthDate));
        }

        return response;
    }
}