namespace AuthService.API.Endpoints;

public static class Register
{
    public static IEndpointRouteBuilder MapRegister(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(EndpointRoutes.Auth.Register, async (RegisterRequest request, ISender mediator, CancellationToken ct) =>
        {
            var cmd = new RegisterCmd(request.UserName, request.Password);
            await mediator.Send(cmd, ct);
            return Results.Ok();
        });

        return endpoints;
    }
}
