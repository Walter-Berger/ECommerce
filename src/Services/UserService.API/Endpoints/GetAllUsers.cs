namespace UserService.API.Endpoints;

public static class GetAllUsers
{
    public static IEndpointRouteBuilder MapGetAllUsers(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(EndpointRoutes.User.GetAll, async (ISender mediator) =>
        {
            var qry = new GetAllUsersQry();
            var results = await mediator.Send(qry);
            var response = results.ToResponse();
            return Results.Ok(response);
        });

        return endpoints;
    }
}
