using Catalog.API.Exceptions;
using Catalog.API.Models;

namespace Catalog.API.Products.GetProductById;

internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
    :IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdQueryHandler.Handle called with request: {@query}", query);
        var product = await session
            .LoadAsync<Product>(query.Id, cancellationToken);
        if (product is not null) return new GetProductByIdResult(product);
        logger.LogWarning("Product with id {Id} not found", query.Id);
        throw new ProductNotFoundException();
    }
}