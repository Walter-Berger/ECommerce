namespace UserService.API.Endpoints;

public static class CreateUser
{
    public static IEndpointRouteBuilder MapCreateUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(EndpointRoutes.User.Create, async (HttpContext context, CreateUserRequest request, ISender mediator) =>
        {
            var test = context.Request.Headers;
            var cmd = request.ToCommand();
            var result = await mediator.Send(cmd);
            return Results.Ok(result);
        });

        return endpoints;
    }
}
