using InventoryMobile.ViewModels;

namespace InventoryMobile.Views;
public partial class LoginPage : ContentPage
{
    
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}