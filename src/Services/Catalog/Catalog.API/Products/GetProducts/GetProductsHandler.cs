using Catalog.API.Models;

namespace Catalog.API.Products.GetProducts;

internal class GetProductsHandler(IDocumentSession session, ILogger<GetProductsHandler> logger)
: IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with query {@query}", query);
        var products = await session.Query<Product>()
            .ToListAsync(cancellationToken);

        return new GetProductsResult(products, products.Count);
    }
}