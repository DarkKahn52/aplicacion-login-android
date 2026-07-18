using CalculadoraUnimex.App.Models;
using CalculadoraUnimex.App.Pages;
using CalculadoraUnimex.App.Services;

namespace CalculadoraUnimex.App;

public partial class MainPage : ContentPage
{
    private readonly ApiService _api;
    public MainPage() : this(IPlatformApplication.Current!.Services.GetRequiredService<ApiService>()) { }
    public MainPage(ApiService api) { InitializeComponent(); _api = api; }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        MessageLabel.IsVisible = false;
        if (string.IsNullOrWhiteSpace(EmailEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text)) { Show("Captura el correo y la contraseña."); return; }
        SetBusy(true);
        try
        {
            var result = await _api.LoginAsync(new LoginRequest(EmailEntry.Text.Trim(), PasswordEntry.Text));
            if (!result.Success) { Show(result.Message); return; }
            await Shell.Current.GoToAsync(nameof(CarPage), new Dictionary<string, object> { ["UserEmail"] = EmailEntry.Text.Trim() });
            PasswordEntry.Text = string.Empty;
        }
        catch (Exception ex) { Show("No se pudo conectar con el servidor. " + ex.Message); }
        finally { SetBusy(false); }
    }
    private async void OnRegisterTapped(object sender, TappedEventArgs e) => await Shell.Current.GoToAsync(nameof(RegisterPage));
    private void Show(string message) { MessageLabel.Text = message; MessageLabel.IsVisible = true; }
    private void SetBusy(bool busy) { Loading.IsVisible = busy; Loading.IsRunning = busy; LoginButton.IsEnabled = !busy; }
}
