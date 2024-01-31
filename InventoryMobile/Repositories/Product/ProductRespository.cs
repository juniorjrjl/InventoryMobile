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
        try
        {
            var response = await Constants.ApiUrl
            .AppendPathSegment("/products")
            .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
            .PostJsonAsync(request);
        
            return response.ResponseMessage.IsSuccessStatusCode;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return false;
    }

    public async Task<IEnumerable<ProductResponse>> GetAsync()
    {
        try{
            return await Constants.ApiUrl
            .AppendPathSegment("/products")
            .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
            .GetJsonAsync<IEnumerable<ProductResponse>>();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return [];
    }

    public async Task<ProductResponse> GetByBarcodeAsync(string barcode) 
    {
        try
        {
            await Constants.ApiUrl
                .AppendPathSegment($"/products/{barcode}")
                .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                .GetJsonAsync<ProductResponse>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return new ProductResponse(Guid.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DateTime.MinValue);
    }
        

    public async Task<bool> UpdateAsync(ProductRequest request)
    {
        try
        {
            var response = await Constants.ApiUrl
                .AppendPathSegment($"/products/{request.ProductId}")
                .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                .PutJsonAsync(request);
            
            return response.ResponseMessage.IsSuccessStatusCode;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return false;
    }
}
