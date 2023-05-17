﻿namespace BookService.API.Extensions;

public static class ApiEndpoints
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder endpoints)
    {
        // map book endpoints
        endpoints.MapCreateBook();
        endpoints.MapBuyBook();

        return endpoints;
    }
}