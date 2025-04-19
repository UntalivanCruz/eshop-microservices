using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateProduct")
            .Accepts<CreateProductRequest>("application/json")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Update an existing product")
            .WithDescription("Update an existing product in the catalog")
            .WithTags("Product");
    }
}