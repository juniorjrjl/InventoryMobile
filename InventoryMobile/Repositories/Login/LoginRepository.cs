using System.Text.Json;
using Flurl;
using Flurl.Http;
using InventoryMobile.Helpers;
using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;

namespace InventoryMobile.Repositories.Login;
public class LoginRepository : ILoginRepository
{
    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var response = await Constants.ApiUrl.AppendPathSegment("/users/login").PutJsonAsync(request);
        var emptyResponse = new LoginResponse("");
        if (!response.ResponseMessage.IsSuccessStatusCode) return emptyResponse;

        var content = await response.ResponseMessage.Content.ReadAsStringAsync();
        return content is not null ? 
            JsonSerializer.Deserialize<LoginResponse>(content):
            emptyResponse;
    }
}
