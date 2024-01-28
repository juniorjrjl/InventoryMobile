using Flunt.Validations;
using InventoryMobile.Models.Request;

namespace InventoryMobile.Contracts;

public class SignupContract : Contract<SignupRequest>
{
    public SignupContract(SignupRequest request)
    {
        Requires()
            .IsNotNullOrEmpty(request.Name, nameof(request.Name), "Informe um nome válido");

        Requires()
            .IsEmail(request.Email, nameof(request.Email), "Informe um e-mail válido")
            .IsNotNullOrEmpty(request.Email, nameof(request.Email), "Informe um e-mail válido");

        Requires()
            .IsNotNullOrEmpty(request.Password, nameof(request.Password), "Informe uma senha válida");
    }
}
