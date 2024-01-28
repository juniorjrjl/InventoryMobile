using CommunityToolkit.Mvvm.ComponentModel;

namespace InventoryMobile.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    string name;

    public MainViewModel()
    {
        Name = "Hello World!";
    }
}