namespace BookService.API.Mappers;

public static class RequestToCmdMapper
{
    public static CreateBookCmd ToCommand(this CreateBookRequest request)
    {
        var result = new CreateBookCmd(
            Title: request.Title,
            Author: request.Author,
            Price: request.Price
        );
        return result;
    }
}
