using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryMobile.Contracts;
using InventoryMobile.Helpers;
using InventoryMobile.Models.Request;
using InventoryMobile.Repositories.Login;
using InventoryMobile.Views;

namespace InventoryMobile.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty]
    string email;

    [ObservableProperty]
    string password;

    private readonly ILoginRepository _repository;

    public LoginViewModel(ILoginRepository repository)
    {
        _repository = repository;
    }

    [RelayCommand]
    public async Task GoToSignup() => await Shell.Current.GoToAsync(nameof(SignupPage));

    [RelayCommand]
    public async Task Login(){
        var request = new LoginRequest(email, password);
        var contract = new LoginContract(request);
        if (!contract.IsValid)
        {
            var messages = contract.Notifications.Select(x => x.Message);
            var sb = new StringBuilder();
            foreach(var message in messages) sb.Append($"{message}\n");

            await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "Ok");
            return;
        }
        var response = await _repository.LoginAsync(request);

        if(response is null || string.IsNullOrEmpty(response.AccessToken))
        {
            var toast = Toast.Make("Falha ao realizar login, tente novamente!", ToastDuration.Long);
            await toast.Show();
            return;
        }

        SessionHelper.SaveToken(response.AccessToken, DateTime.Now.AddHours(3));
        await Shell.Current.GoToAsync($"//{nameof(ProductsPage)}");
    }

}
