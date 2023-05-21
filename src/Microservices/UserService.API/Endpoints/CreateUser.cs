namespace UserService.API.Endpoints;

public static class CreateUser
{
    public static IEndpointRouteBuilder MapCreateUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(EndpointRoutes.User.Create, async (CreateUserRequest request, ISender mediator, CancellationToken ct) =>
        {
            var cmd = new CreateUserCmd(
                Email: request.Email,
                FirstName: request.FirstName,
                LastName: request.LastName,
                BirthDate: request.BirthDate);

            await mediator.Send(cmd, ct);
            return Results.Ok();
        })
        .RequireAuthorization();

        return endpoints;
    }
}
