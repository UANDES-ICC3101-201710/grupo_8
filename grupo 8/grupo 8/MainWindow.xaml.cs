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

namespace HearthstoneProject
{
    /// <summary>
    /// Lógica de interacción para Nueva_Partida.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bnueva_Click(object sender, RoutedEventArgs e)
        {
            Nueva_Partida npar = new Nueva_Partida();
            npar.Show();
            Close();
        }

        private void Bcargar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bsalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
