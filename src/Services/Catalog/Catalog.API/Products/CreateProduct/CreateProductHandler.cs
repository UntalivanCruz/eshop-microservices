using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

internal class CreateProductCommandHandler(IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.Adapt<Product>();

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        
        return new CreateProductResult(product.Id);
    }
}