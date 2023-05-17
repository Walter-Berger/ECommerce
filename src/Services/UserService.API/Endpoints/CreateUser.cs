namespace UserService.API.Endpoints;

public static class CreateUser
{
    public static IEndpointRouteBuilder MapCreateUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(EndpointRoutes.User.Create, async (CreateUserRequest request, ISender mediator) =>
        {
            var cmd = request.ToCommand();
            var result = await mediator.Send(cmd);
            return Results.Ok(result);
        });

        return endpoints;
    }
}
