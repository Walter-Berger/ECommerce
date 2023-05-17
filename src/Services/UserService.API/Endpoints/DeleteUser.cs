namespace UserService.API.Endpoints;

public static class DeleteUser
{
    public static IEndpointRouteBuilder MapDeleteUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapDelete(EndpointRoutes.User.Delete, async (Guid id, ISender mediator) =>
        {
            var qry = new DeleteUserCmd(id);
            var result = await mediator.Send(qry);
            return Results.Ok(result);
        });

        return endpoints;
    }
}
