using Flunt.Validations;
using InventoryMobile.Models.Request;

namespace InventoryMobile.Contracts
{
    public class LoginContract : Contract<LoginRequest>
    {
        public LoginContract(LoginRequest request)
        {
            Requires()
                .IsNotNullOrEmpty(request.Email, nameof(request.Email), "Informe um e-mail válido")
                .IsEmail(request.Email, nameof(request.Email), "Informe um e-mail válido")
                .IsNotNullOrEmpty(request.Password, nameof(request.Password), "Informe uma senha válida");
        }
    }
}