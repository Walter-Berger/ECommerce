namespace AccountService.Endpoints;

public static class UpdateUser
{
    public static IEndpointRouteBuilder MapUpdateUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut(EndpointRoutes.User.Update,
            async (HttpContext context, UpdateUserRequest request, ISender mediator, CancellationToken ct) =>
            {
                var claims = context.User.Claims;
                var userId = claims.FirstOrDefault(c => c.Type == "userId")!.Value;

                var cmd = new UpdateUserCmd(
                    Id: Guid.Parse(userId),
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
