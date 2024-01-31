using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryMobile.Contracts;
using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;
using InventoryMobile.Repositories.Product;
using InventoryMobile.Views;

namespace InventoryMobile.ViewModels;

[QueryProperty(nameof(Product), nameof(Product))]
public partial class EditProductViewModel : BaseViewModel
{

    private ProductResponse _product;
    public ProductResponse Product
    {
        get => _product;
        set
        {
            SetProperty(ref _product, value);

            if (value is not null)
            {
                ProductId = value.ProductId;
                Barcode = value.Barcode;
                Description = value.Description;
                Stock = value.Stock;
                Price = value.Price;
            }
        }
    } 


    [ObservableProperty]
    Guid productId;

    [ObservableProperty]
    string barcode;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    int? stock;

    [ObservableProperty]
    double? price;

    private readonly IProductRepository _repository;

    public EditProductViewModel(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task GetInfoProductAsync(string barcode)
    {
        var product = await _repository.GetByBarcodeAsync(barcode);

        if (product is null)
            return;

        productId = product.ProductId;
        barcode = product.Barcode;
        description = product.Description;
        stock = product.Stock;
        price = product.Price;

    }

    [RelayCommand]
    public async Task Save()
    {
        var request = new ProductRequest
        {
            ProductId = productId,
            Barcode = barcode,
            Description = description,
            Stock = stock??0,
            UnitOfMeasurement = "Unidade",
            Price = price??0,
            UpdatedAt = DateTime.Now
        };

        var contract = new ProductContract(request);

        if (!contract.IsValid)
        {
            var messages = contract.Notifications.Select(x => x.Message);
            var sb = new StringBuilder();
            foreach(var message in messages) sb.Append($"{message}\n");

            await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "Ok");
            return;
        }

        var result = await _repository.UpdateAsync(request);
        IToast toast;
        if (!result)
        {
            toast = Toast.Make("Falha ao atualizar o estoque, tente novamente!", ToastDuration.Long);
            await toast.Show();
            return;
        }

        toast = Toast.Make("Estoque atualizado com sucesso!", ToastDuration.Long);
        await toast.Show();
        await Shell.Current.GoToAsync($"//{nameof(ProductsPage)}");
    }

}
