using InventoryMobile.Views;

namespace InventoryMobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
		Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));
		Routing.RegisterRoute(nameof(EditProductPage), typeof(EditProductPage));
	}
}
