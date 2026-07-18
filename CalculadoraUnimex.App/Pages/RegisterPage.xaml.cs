using CalculadoraUnimex.App.Models;
using CalculadoraUnimex.App.Services;
namespace CalculadoraUnimex.App.Pages;
public partial class RegisterPage : ContentPage
{
 private readonly ApiService _api; public RegisterPage() : this(IPlatformApplication.Current!.Services.GetRequiredService<ApiService>()) { }
    public RegisterPage(ApiService api){InitializeComponent();_api=api;}
 private async void OnRegisterClicked(object sender, EventArgs e){MessageLabel.IsVisible=false;if(string.IsNullOrWhiteSpace(NameEntry.Text)||string.IsNullOrWhiteSpace(EmailEntry.Text)||string.IsNullOrWhiteSpace(PasswordEntry.Text)||string.IsNullOrWhiteSpace(ConfirmEntry.Text)){Show("Todos los campos son obligatorios.",false);return;} if(PasswordEntry.Text!=ConfirmEntry.Text){Show("Las contraseñas no coinciden.",false);return;} SetBusy(true);try{var r=await _api.RegisterAsync(new RegisterRequest(NameEntry.Text.Trim(),EmailEntry.Text.Trim(),PasswordEntry.Text,ConfirmEntry.Text));Show(r.Message,r.Success);if(r.Success){await DisplayAlert("Registro exitoso",r.Message,"Aceptar");await Shell.Current.GoToAsync("..");}}catch(Exception ex){Show("No se pudo conectar con el servidor. "+ex.Message,false);}finally{SetBusy(false);}}
 private async void OnBackClicked(object sender,EventArgs e)=>await Shell.Current.GoToAsync("..");
 private void Show(string m,bool ok){MessageLabel.Text=m;MessageLabel.TextColor=ok?Color.FromArgb("#69F0AE"):Color.FromArgb("#FF8A80");MessageLabel.IsVisible=true;} private void SetBusy(bool b){Loading.IsVisible=b;Loading.IsRunning=b;RegisterButton.IsEnabled=!b;}
}
