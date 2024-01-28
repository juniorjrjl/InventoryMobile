using System.Text.Json.Serialization;

namespace InventoryMobile.Models.Request;

public record ProductRequest
{
    [JsonPropertyName("productId")]
    public Guid ProductId  { get; init;} = Guid.NewGuid();
    [JsonPropertyName("descricao")]
    public required string Description  { get; init;}
    [JsonPropertyName("estoque")]
    public required int Stock  { get; init;}
    [JsonPropertyName("barcode")]
    public required string Barcode  { get; init;}
    [JsonPropertyName("unidadeMedida")]
    public required string UnitOfMeasurement  { get; init;}
    [JsonPropertyName("preco")]
    public required double Price  { get; init;}
    [JsonPropertyName("atualizadoEm")]
    public required DateTime UpdatedAt { get; init;}
}
