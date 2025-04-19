using Catalog.API.Models;
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductsByCategory;

internal class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
{
    public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsByCategoryQueryHandler.Handle called with request: {@query}", query);
        var products = await session.Query<Product>()
            .Where(x => x.Category.Contains(query.Category))
            .ToListAsync(token: cancellationToken);
        
        logger.LogInformation("GetProductsByCategoryQueryHandler.Handle found {Count} products", products.Count);
        return new GetProductsByCategoryResult(products);
    }
}