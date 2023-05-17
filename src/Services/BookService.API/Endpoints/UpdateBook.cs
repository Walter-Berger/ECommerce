namespace BookService.API.Endpoints;

public static class UpdateBook
{
    public static IEndpointRouteBuilder MapUpdateBook(this IEndpointRouteBuilder endpoint)
    {
        endpoint.MapPut(EndpointRoutes.Book.Update,  async (Guid id, UpdateBookRquest request, ISender mediator) =>
        {
            var cmd = request.ToCommand(id);
            var response = await mediator.Send(cmd);
            return Results.Ok(response);
        });

        return endpoint;
    }
}
