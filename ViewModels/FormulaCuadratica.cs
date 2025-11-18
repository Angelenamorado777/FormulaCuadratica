namespace FormulaCuadratica.ViewsModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class FormulacuadraticaViewModel : ObservableObject
{
    [ObservableProperty]
    private double a;

    [ObservableProperty]
    private double b;

    [ObservableProperty]
    private double c;

    [ObservableProperty]
    private double x1;

    [ObservableProperty]
    private double x2;

    [RelayCommand]
    private async Task Calcular()
    {
        var formulacuadratica = new Formulacuadratica(A, B, C);


        if (formulacuadratica.A == 0)
        {
            if (Application.Current?.MainPage is not null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ADVERTENCIA",
                    "El coeficiente 'a' no puede ser un valor cero.",
                    "Aceptar"
                );
            }
            return;
        }

        double discriminante = Math.Pow(formulacuadratica.B, 2) -
                               4 * formulacuadratica.A * formulacuadratica.C;

        if (discriminante < 0)
        {
            if (Application.Current?.MainPage is not null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "ADVERTENCIA",
                    "No se puede calcular la raíz cuadrada de un número negativo.",
                    "Aceptar"
                );
            }
            return;
        }

        X1 = (-formulacuadratica.B + Math.Sqrt(discriminante)) / (2 * formulacuadratica.A);
        X2 = (-formulacuadratica.B - Math.Sqrt(discriminante)) / (2 * formulacuadratica.A);
    }
}