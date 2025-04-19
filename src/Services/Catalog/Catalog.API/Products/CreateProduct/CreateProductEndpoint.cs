namespace Catalog.API.Products.CreateProduct;

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
                {
                    var command = request.Adapt<CreateProductCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<CreateProductResponse>();

                    return Results.Created($"/products/{response.Id}", response);
                })
            .WithName("CreateProduct")
            .Accepts<CreateProductRequest>("application/json")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithSummary("Create a new product")
            .WithDescription("Create a new product in the catalog")
            .WithTags("Product");
    }
}