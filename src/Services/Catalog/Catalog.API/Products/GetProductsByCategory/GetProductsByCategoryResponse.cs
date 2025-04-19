using Catalog.API.Models;

namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductsByCategoryResponse(IEnumerable<Product> Products);