namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(
    Guid Id,
    string Name,
    List<string> Categories,
    string Description,
    string ImageFile,
    decimal Price
);