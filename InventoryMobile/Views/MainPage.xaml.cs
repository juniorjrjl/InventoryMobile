using InventoryMobile.ViewModels;

namespace InventoryMobile.Views;
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
