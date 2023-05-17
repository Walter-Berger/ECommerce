namespace UserService.API.Features.GetAllUsers;


public class GetAllUsersQryHandler : IRequestHandler<GetAllUsersQry, List<GetAllUsersQryResult>>
{
    private readonly DatabaseContext _databaseContext;

    public GetAllUsersQryHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<GetAllUsersQryResult>> Handle(GetAllUsersQry request, CancellationToken cancellationToken)
    {
        // check if there are users in database
        var users = await _databaseContext.Users.ToListAsync(cancellationToken);
        if (!users.Any())
        {
            throw new NotFoundException(ErrorDetails.UsersNotFound);
        }

        // return them
        return users.ToResult();
    }
}
