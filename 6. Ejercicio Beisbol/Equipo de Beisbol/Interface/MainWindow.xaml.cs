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
        private List<Pitcher> pitchers;
        private List<JugadorDePosicion> jugadoresDePosicion;
        private List<BateadorDesignado> bateadoresDesignados;
        public MainWindow()
        {
            InitializeComponent();
            InicializarDatos();
        }
        private void InicializarDatos()
        {
            pitchers = new List<Pitcher>
            {
                new Pitcher(10, "Luis", 10, 2)
            };

            jugadoresDePosicion = new List<JugadorDePosicion>
            {
                new JugadorDePosicion(5, "Andres", 10, 4)
            };

            bateadoresDesignados = new List<BateadorDesignado>
            {
                new BateadorDesignado(4, "Carlos", 15)
            };
        }

        private void BtnCapturarDatos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RbtJugadorPosicion.IsChecked == false && RbtBateadorDesignado.IsChecked == false && RbtPitcher.IsChecked == false)
                {
                    MessageBox.Show("Debe seleccionar una posición", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (RbtJugadorPosicion.IsChecked == true)
                {
                    JugadorDePosicion jugadorDePosicion = new JugadorDePosicion(
                        Convert.ToInt32(TxbUniforme.Text),
                        TxbNombre.Text,
                        Convert.ToInt32(TxbHits.Text),
                        Convert.ToInt32(TxbErrores.Text)
                    );
                    jugadoresDePosicion.Add(jugadorDePosicion);
                    MessageBox.Show("Jugador de posición agregado correctamente");
                }
                else if (RbtBateadorDesignado.IsChecked == true)
                {
                    BateadorDesignado bateadorDesignado = new BateadorDesignado(
                         Convert.ToInt32(TxbUniforme.Text),
                         TxbNombre.Text,
                         Convert.ToInt32(TxbHits.Text)
                     );
                    bateadoresDesignados.Add(bateadorDesignado);
                    MessageBox.Show("Bateador designado agregado correctamente");
                }
                else if (RbtPitcher.IsChecked == true)
                {
                    Pitcher pitcher = new Pitcher(
                         Convert.ToInt32(TxbUniforme.Text),
                         TxbNombre.Text,
                         Convert.ToInt32(TxbPonches.Text),
                         Convert.ToInt32(TxbErrores.Text)
                     );
                    pitchers.Add(pitcher);
                    MessageBox.Show("Pitcher agregado correctamente");
                }
                ClearTextBox();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores válidos para cada campo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ClearTextBox();
        }

        private void BtnMostrarDatos_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder datos = new StringBuilder();
            if (RbtJugadorPosicion.IsChecked == true)
            {
                foreach (var jugador in jugadoresDePosicion)
                {
                    datos.AppendLine(jugador.MostrarDatos());
                }
            }
            else if (RbtBateadorDesignado.IsChecked == true)
            {
                foreach (var bateador in bateadoresDesignados)
                {
                    datos.AppendLine(bateador.MostrarDatos());
                }
            }
            else if (RbtPitcher.IsChecked == true)
            {
                foreach (var pitcher in pitchers)
                {
                    datos.AppendLine(pitcher.MostrarDatos());
                }
            }
            MessageBox.Show(datos.ToString(), "Jugadores");
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearTextBox()
        {
            foreach (var control in (this.Content as Grid).Children)
            {
                if (control is GroupBox groupBox)
                {
                    foreach (var innerControl in (groupBox.Content as Canvas).Children)
                    {
                        if (innerControl is TextBox textBox)
                        {
                            textBox.Clear();
                        }
                    }
                }
            }
        }

        private void Txb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void Txb2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void Txb_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            e.CancelCommand();
        }

        private void RbtPitcher_Checked(object sender, RoutedEventArgs e)
        {
            TxbHits.IsEnabled= false;
            TxbErrores.IsEnabled= true;
            TxbPonches.IsEnabled= true;
        }

        private void RbtJugadorPosicion_Checked(object sender, RoutedEventArgs e)
        {
            TxbHits.IsEnabled = true;
            TxbErrores.IsEnabled = true;
            TxbPonches.IsEnabled = false;
        }

        private void RbtBateadorDesignado_Checked(object sender, RoutedEventArgs e)
        {
            TxbHits.IsEnabled = true;
            TxbErrores.IsEnabled = false;
            TxbPonches.IsEnabled = false;
        }
    }


}