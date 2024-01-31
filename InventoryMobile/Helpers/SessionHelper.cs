using InventoryMobile.Views;

namespace InventoryMobile.Helpers;

public static class SessionHelper
{
    
    public static void SaveToken(string token, DateTime expiresIn)
    {
        Preferences.Set("token", token);
        Preferences.Set("ExpirateDateTimeKey", expiresIn);
    }

    public static async Task<string> GetTokenAsync()
    {
        var expireDateTime = Preferences.Get("ExpirateDateTimeKey", DateTime.MinValue);
        var token = Preferences.Get("token", string.Empty);

        if (expireDateTime <= DateTime.Now)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            return string.Empty;
        }

        return token;
    }

}
