using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;

namespace InventoryMobile.Repositories.Product;

public interface IProductRepository
{
    Task<IEnumerable<ProductResponse>> GetAsync();

    Task<bool> AddAsync(ProductRequest request);

    Task<bool> UpdateAsync(ProductRequest request);

}
