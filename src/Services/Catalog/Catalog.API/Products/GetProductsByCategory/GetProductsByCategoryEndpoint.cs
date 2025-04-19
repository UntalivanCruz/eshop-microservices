using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductsByCategory;

public class GetProductsByCategoryEndpoint:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var query = new GetProductsByCategoryQuery(category);
            var result = await sender.Send(query);
            var response = result.Adapt<GetProductsByCategoryResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProductsByCategory")
        .WithTags("Product")
        .Produces<GetProductsByCategoryResult>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status500InternalServerError)
        .WithSummary("Get products by category")
        .WithDescription("Get products by category");
    }
}