using CalculadoraUnimex.App.Pages;

namespace CalculadoraUnimex.App;

public partial class AppSell : Shell
{
    public AppSell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(CarPage), typeof(CarPage));
    }
}
