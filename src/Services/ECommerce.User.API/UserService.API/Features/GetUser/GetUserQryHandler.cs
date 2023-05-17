namespace UserService.API.Features.GetUser;


public class GetUserQryHandler : IRequestHandler<GetUserQry, GetUserQryResult>
{
    private readonly DatabaseContext _databaseContext;

    public GetUserQryHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<GetUserQryResult> Handle(GetUserQry request, CancellationToken cancellationToken)
    {
        // check if user exists in database
        var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (user is null)
        {
            throw new NotFoundException(ErrorDetails.UserNotFound);
        }

        // return user
        return user.ToResult();
    }
}
