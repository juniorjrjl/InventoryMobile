using System.Text.Json.Serialization;

namespace InventoryMobile.Models.Response;

public record LoginResponse(
    [property:JsonPropertyName("AccessToken")]
    string AccessToken
    )
{
    
}
