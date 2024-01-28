using System.Text.Json.Serialization;

namespace InventoryMobile.Models.Request;

public record SignupRequest
{
    [JsonPropertyName("usuarioId")]
    public Guid UserId { get; init;} = Guid.NewGuid();
    [JsonPropertyName("nome")]
    public required string Name { get; init;}
    [JsonPropertyName("email")]
    public required string Email { get; init;}
    [JsonPropertyName("senha")]
    public required string Password { get; init;}
}
