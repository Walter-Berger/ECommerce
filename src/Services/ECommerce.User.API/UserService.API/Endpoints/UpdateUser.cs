namespace UserService.API.Endpoints;

public static class UpdateUser
{
    public static IEndpointRouteBuilder MapUpdateUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut(EndpointRoutes.User.Update, async (Guid id, UpdateUserRequest request, ISender mediator) =>
        {
            var cmd = request.ToCommand(id);
            var result = await mediator.Send(cmd);
            return Results.Ok(result);
        });

        return endpoints;
    }
}
