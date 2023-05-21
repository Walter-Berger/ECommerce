namespace AccountService.Endpoints;

public static class GetUser
{
    public static IEndpointRouteBuilder MapGetUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(EndpointRoutes.User.Get, async (HttpContext context, ISender mediator, CancellationToken ct) =>
        {
            var claims = context.User.Claims;
            var userId = claims.FirstOrDefault(c => c.Type == "userId")!.Value;

            var qry = new GetUserQry(Guid.Parse(userId));
            var result = await mediator.Send(qry, ct);
            var response = new GetUserResponse(
                Id: result.Id,
                Email: result.Email,
                FirstName: result.FirstName,
                LastName: result.LastName,
                BirthDate: result.BirthDate);

            return Results.Ok(response);
        })
        .RequireAuthorization();

        return endpoints;
    }
}
  