using System.Text.Json.Serialization;

namespace InventoryMobile.Models.Response;

public record ProductResponse(
    [property:JsonPropertyName("productId")]
    Guid ProductId,
    [property:JsonPropertyName("descricao")]
    string Description,
    [property:JsonPropertyName("estoque")]
    int Stock,
    [property:JsonPropertyName("barcode")]
    string Barcode,
    [property:JsonPropertyName("unidadeMedida")]
    string UnitOfMeasurement,
    [property:JsonPropertyName("preco")]
    double Price,
    [property:JsonPropertyName("atualizadoEm")]
    DateTime UpdatedAt
)
{
    
}
