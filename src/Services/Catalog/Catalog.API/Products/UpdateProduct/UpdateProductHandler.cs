using Catalog.API.Exceptions;
using Catalog.API.Models;

namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger)
: ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if (product is null)
        {
            logger.LogWarning("Product with id {Id} not found", command.Id);
            throw new ProductNotFoundException();
        }
        
        product = command.Adapt<Product>();

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
