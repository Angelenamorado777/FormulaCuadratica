using FormulaCuadratica.Views;

namespace FormulaCuadratica;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new FormulaCuadraticaView();
    }
}