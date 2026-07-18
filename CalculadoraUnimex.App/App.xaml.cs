namespace CalculadoraUnimex.App;

public partial class App : Application
{
    public App(AppSell shell)
    {
        InitializeComponent();
        MainPage = shell;
    }
}
