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
    /// Lógica de interacción para Partida.xaml
    /// </summary>
    public partial class Partida : Window
    {
        Heroe jugador1;
        Heroe jugador2;
        public Partida(Heroe jug1, Heroe jug2)
        {
            jugador1 = jug1;
            jugador2 = jug2;
            InitializeComponent();
        }
    }
}
