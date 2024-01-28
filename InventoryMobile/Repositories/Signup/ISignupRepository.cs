using InventoryMobile.Models.Request;

namespace InventoryMobile.Repositories.Signup;
public interface ISignupRepository
{
    Task<bool> CreateUserAsync(SignupRequest request);
    
}
