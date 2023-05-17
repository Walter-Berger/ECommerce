namespace UserService.API.Endpoints;

public static class GetUser
{
    public static IEndpointRouteBuilder MapGetUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(EndpointRoutes.User.Get, async (Guid id, ISender mediator) =>
        {
            var qry = new GetUserQry(id);
            var result = await mediator.Send(qry);
            var response = result.ToResponse();
            return Results.Ok(response);
        });

        return endpoints;
    }
}
  