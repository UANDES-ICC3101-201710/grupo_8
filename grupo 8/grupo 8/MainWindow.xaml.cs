using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace HearthstoneProject
{
    /// <summary>
    /// Lógica de interacción para Nueva_Partida.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lable.Visibility = Visibility.Hidden;
            TBox.Visibility = Visibility.Hidden;
        }

        private void Bnueva_Click(object sender, RoutedEventArgs e)
        {
            Nueva_Partida npar = new Nueva_Partida();
            npar.Show();
            Close();
        }

        private void Bcargar_Click(object sender, RoutedEventArgs e)
        {
            if (TBox.Visibility==Visibility.Hidden)
            {
                lable.Visibility = Visibility.Visible;
                TBox.Visibility = Visibility.Visible;
            }
            else
            {
                Partida p = new Partida(LoadGame(TBox.Text));
                p.Show();
                Close();
            }
        }

        private void Bsalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private static Heroe LoadGame(string nombrePartida)
        {
            //Aqui deberia de asignar un nombre de archivo para abrir la partida
            string fileName = nombrePartida;
            // Creamos el Stream donde se encuentra nuestro juego
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Heroe jugador = formatter.Deserialize(fs) as Heroe;
            fs.Close();
            return jugador;
        }
    }
}
