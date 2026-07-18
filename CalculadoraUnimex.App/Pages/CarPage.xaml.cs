using CalculadoraUnimex.App.Services;
namespace CalculadoraUnimex.App.Pages;
[QueryProperty(nameof(UserEmail),"UserEmail")]
public partial class CarPage : ContentPage
{
 private readonly ApiService _api; private string _userEmail=""; public string UserEmail{get=>_userEmail;set{_userEmail=value;UserLabel.Text=value;}}
 public CarPage() : this(IPlatformApplication.Current!.Services.GetRequiredService<ApiService>()) { }
    public CarPage(ApiService api){InitializeComponent();_api=api;}
 protected override async void OnAppearing(){base.OnAppearing();if(CarImage.Source is null)await LoadCarAsync();}
 private async void OnChangeCarClicked(object sender,EventArgs e)=>await LoadCarAsync();
 private async Task LoadCarAsync(){SetBusy(true);try{var car=await _api.GetRandomCarAsync();CarImage.Source=ImageSource.FromUri(new Uri(car.Imagen));MessageLabel.IsVisible=false;}catch(Exception ex){MessageLabel.Text="No se pudo cargar la imagen. "+ex.Message;MessageLabel.IsVisible=true;}finally{SetBusy(false);}}
 private async void OnLogoutClicked(object sender,EventArgs e){await Shell.Current.GoToAsync("//login");}
 private void SetBusy(bool b){Loading.IsVisible=b;Loading.IsRunning=b;ChangeButton.IsEnabled=!b;}
}
