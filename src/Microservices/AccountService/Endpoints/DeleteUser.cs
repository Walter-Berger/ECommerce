using System.Security.Claims;

namespace AccountService.Endpoints;

public static class DeleteUser
{
    public static IEndpointRouteBuilder MapDeleteUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapDelete(EndpointRoutes.User.Delete, async (HttpContext context, ISender mediator, CancellationToken ct) =>
        {
            var claims = context.User.Claims;
            var userId = claims.FirstOrDefault(c => c.Type == "userId")!.Value;

            var cmd = new DeleteUserCmd(Guid.Parse(userId));
            await mediator.Send(cmd, ct);
            return Results.Ok();
        })
        .RequireAuthorization();

        return endpoints;
    }
}
