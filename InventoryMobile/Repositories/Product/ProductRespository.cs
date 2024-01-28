using Flurl;
using Flurl.Http;
using InventoryMobile.Helpers;
using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;

namespace InventoryMobile.Repositories.Product;

public class ProductRespository : IProductRepository
{
    public async Task<bool> AddAsync(ProductRequest request)
    {
        var response = await Constants.ApiUrl
            .AppendPathSegment("/products")
            .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
            .PostJsonAsync(request);
        
        return response.ResponseMessage.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<ProductResponse>> GetAsync() =>
        await Constants.ApiUrl
            .AppendPathSegment("/products")
            .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
            .GetJsonAsync<IEnumerable<ProductResponse>>();


    public async Task<bool> UpdateAsync(ProductRequest request)
    {
        throw new NotImplementedException();
    }
}
