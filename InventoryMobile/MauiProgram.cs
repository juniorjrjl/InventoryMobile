using CommunityToolkit.Maui;
using InventoryMobile.Repositories.Login;
using InventoryMobile.Repositories.Signup;
using InventoryMobile.ViewModels;
using InventoryMobile.Views;
using Microsoft.Extensions.Logging;

namespace InventoryMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
		builder.Services.AddScoped<ILoginRepository, LoginRepository>();
		builder.Services.AddScoped<ISignupRepository, SignupRepository>();

		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<SignupViewModel>();

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<SignupPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
