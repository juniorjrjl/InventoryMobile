using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryMobile.Contracts;
using InventoryMobile.Models.Request;
using InventoryMobile.Repositories.Signup;

namespace InventoryMobile.ViewModels;

public partial class SignupViewModel : BaseViewModel
{
    private readonly ISignupRepository _repository;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string password;

    public SignupViewModel(ISignupRepository repository)
    {
        _repository = repository;
    }

    [RelayCommand]
    public async Task Signup()
    {
        var request = new SignupRequest
        {
            Name = name, 
            Email = email, 
            Password = password
        };

        var contract = new SignupContract(request);
        if (!contract.IsValid)
        {
            var messages = contract.Notifications.Select(x => x.Message);
            var sb = new StringBuilder();
            foreach(var message in messages) sb.Append($"{message}\n");

            await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "Ok");
            return;
        }

        var result = await _repository.CreateUserAsync(request);

        if (result) 
        {
            var toast = Toast.Make("Usuário cadastrado com sucesso", CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toast.Show();

            await Shell.Current.GoToAsync("..");
        }
        else
        {
            var toast = Toast.Make("Erro ao cadastrar o usuário", CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toast.Show();
        }

    }

}
