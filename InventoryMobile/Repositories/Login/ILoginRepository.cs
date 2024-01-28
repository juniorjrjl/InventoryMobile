using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;

namespace InventoryMobile.Repositories.Login;

public interface ILoginRepository
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}
