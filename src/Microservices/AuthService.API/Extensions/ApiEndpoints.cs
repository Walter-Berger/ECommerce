namespace AuthService.API.Extensions;

public static class ApiEndpoints
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder endpoints)
    {
        // map auth endpoints
        endpoints.MapLogin();
        endpoints.MapRegister();

        return endpoints;
    }
}