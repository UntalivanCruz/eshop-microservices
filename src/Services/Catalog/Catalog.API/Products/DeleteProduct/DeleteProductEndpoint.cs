namespace Catalog.API.Products.DeleteProduct;

public class DeleteProductEndpoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("products/{id:guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new DeleteProductCommand(id);
                var result = await sender.Send(command, cancellationToken);
                return result.IsDeleted ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteProductEndpoint")
            .WithTags("Product")
            .Produces<DeleteProductResult>(StatusCodes.Status204NoContent)
            .Produces<DeleteProductResult>(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription("Delete a product by id")
            .WithSummary("Delete a product by id");
    }
}