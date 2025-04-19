using Catalog.API.Models;

namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery() : IQuery<GetProductsResult>;

public record GetProductsResult(
    IEnumerable<Product> Products,
    int TotalCount
);