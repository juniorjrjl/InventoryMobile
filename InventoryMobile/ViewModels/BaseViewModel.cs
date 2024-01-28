using CommunityToolkit.Mvvm.ComponentModel;

namespace InventoryMobile.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    bool isBusy;
    
}