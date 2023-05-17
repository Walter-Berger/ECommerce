namespace BookService.API.Endpoints;

public static class BuyBook
{
    public static IEndpointRouteBuilder MapBuyBook(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(EndpointRoutes.Book.Buy, async (Guid id, ISender mediator) =>
        {
            var cmd = new BuyBookCmd(id);
            var result = await mediator.Send(cmd);
            return Results.Ok(result);
        });

        return endpoints;
    }
}
