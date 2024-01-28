using Flurl;
using Flurl.Http;
using InventoryMobile.Helpers;
using InventoryMobile.Models.Request;

namespace InventoryMobile.Repositories.Signup;

public class SignupRepository : ISignupRepository
{
    public async Task<bool> CreateUserAsync(SignupRequest request)
    {
        var response = await Constants.ApiUrl
            .AppendPathSegment("/users")
            .PostJsonAsync(request);

        return response.ResponseMessage.IsSuccessStatusCode;
    }
}
