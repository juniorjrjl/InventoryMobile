using System.Text.Json.Serialization;

namespace InventoryMobile.Models.Request;

public record LoginRequest(
    [property:JsonPropertyName("email")]
    string Email, 
    [property:JsonPropertyName("senha")]
    string Password)
{
    
}
