namespace UserService.API.Mappers;

public static class UserToResultMapper
{
    private static readonly ITimeFactory _timeFactory = new TimeFactory();

    public static GetUserQryResult ToResult(this User user)
    {
        var result = new GetUserQryResult(
            Id: user.Id,
            Email: user.Email,
            FirstName: user.FirstName,
            LastName: user.LastName,
            BirthDate: _timeFactory.UnixTimeToDateString(user.BirthDateTimestampUnix)
        );
        return result;
    }

    public static List<GetAllUsersQryResult> ToResult(this List<User> users)
    {
        var results = new List<GetAllUsersQryResult>();
        foreach (var user in users)
        {
            results.Add(new GetAllUsersQryResult(
            Id: user.Id,
            Email: user.Email,
            FirstName: user.FirstName,
            LastName: user.LastName,
            BirthDate: _timeFactory.UnixTimeToDateString(user.BirthDateTimestampUnix)));
        }
        return results;
    }
}
