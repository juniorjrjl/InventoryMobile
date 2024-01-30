using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryMobile.Contracts;
using InventoryMobile.Models.Request;
using InventoryMobile.Repositories.Product;

namespace InventoryMobile.ViewModels;

public partial class AddProductViewModel : BaseViewModel
{
    
    [ObservableProperty]
    string barcode;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    int? stock;

    [ObservableProperty]
    double? price;

    private readonly IProductRepository _repository;

    public AddProductViewModel(IProductRepository repository)
    {
        _repository = repository;
    }

    [RelayCommand]
    public async Task Save()
    {
        var request = new ProductRequest
        {
            Description = description,
            Stock = stock.Value,
            Barcode = barcode,
            UnitOfMeasurement = "Unidade",
            Price = price.Value,
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

        var result = await _repository.AddAsync(request);

        IToast toast;
        if (!result)
        {
            toast = Toast.Make("Falha ao cadastrar o produto, tente novamente!", ToastDuration.Long);
            await toast.Show();
            return;
        }

        toast = Toast.Make("Produto cadastrado com sucesso!", ToastDuration.Long);
        await toast.Show();
        await Shell.Current.GoToAsync("..");
    }

}
