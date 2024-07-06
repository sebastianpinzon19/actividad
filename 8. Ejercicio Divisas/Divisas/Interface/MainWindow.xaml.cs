using Models;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConvertir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double pesos = Convert.ToDouble(TxbPesos.Text);
                double cambio = Convert.ToDouble(TxbCambio.Text);
                CambioDivisas cambioDivisas = new CambioDivisas(pesos, cambio);
                double dolares = cambioDivisas.ConvertirADolares(cambioDivisas.Pesos, cambioDivisas.TipoCambio);
                string dolaresFormateados = dolares.ToString("F2");
                MessageBox.Show($"Se aplicara un cambio de {cambioDivisas.Pesos} Pesos a una tasa de cambio de 1 USD = {cambioDivisas.TipoCambio}");
                LblResultado.Content = $"Al aplicar la tasa de cambio se obtendran {dolaresFormateados} USD";
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores validos para cada campo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ae)
            {

                MessageBox.Show(ae.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Txb_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        private void Txb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]*(\\,[0-9]*)?$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}