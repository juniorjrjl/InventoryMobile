using Flunt.Validations;
using InventoryMobile.Models.Request;

namespace InventoryMobile.Contracts;

public class ProductContract : Contract<ProductRequest>
{
    public ProductContract(ProductRequest request)
    {
        Requires()
            .IsNotEmpty(request.ProductId, nameof(request.ProductId), "Informe o identificador do produto");

        Requires()
            .IsNotNullOrEmpty(request.Description, nameof(request.ProductId), "Informe a descrição do produto");

        Requires()
            .IsGreaterThan(request.Stock, -1, nameof(request.Stock), "Informe uma quantidade válida para o produto");

        Requires()
            .IsNotNullOrEmpty(request.Barcode, nameof(request.Barcode), "Informe o código de barras do produto");
        
        Requires()
            .IsNotNullOrEmpty(request.UnitOfMeasurement, nameof(request.UnitOfMeasurement), "Informe a unidade de medida do produto");

        Requires()
            .IsGreaterThan(request.Price, -1, nameof(request.Price), "Informe um preço válido para o produto");

    }
}