namespace BookService.API.Endpoints;

public static class CreateBook
{
    public static IEndpointRouteBuilder MapCreateBook(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost(EndpointRoutes.Book.Create, async (CreateBookRequest request, ISender mediator) =>
        {
            var cmd = request.ToCommand();
            var result = await mediator.Send(cmd);  
            return Results.Ok();
        });

        return endpoints;
    }
}
