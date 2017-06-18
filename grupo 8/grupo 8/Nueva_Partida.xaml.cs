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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HearthstoneProject
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Nueva_Partida : Window
    {
        //Atributos para la creación de heroes:
        Heroe j1;
        Heroe j2;
        List<Heroe> coin = new List<Heroe>();

        //Constructor:
        public Nueva_Partida()
        {
            InitializeComponent();
            Lporfa.Visibility = Visibility.Hidden;
            Lporfa2.Visibility = Visibility.Hidden;
            j1 = new Heroe(null, null, null, null, null, null, null, null, null,null);
            j2 = new Heroe(null, null, null, null, null, null, null, null, j1,null);
            j1.enemigo = j2;
        }

        //Método útil para desordenar el mazo:
        public static List<T> DesordenarLista<T>(List<T> input)
        {
            List<T> arr = input;
            List<T> arrDes = new List<T>();

            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }

            return arrDes;
        }

        //Método para definir las caracteristicas de un héroe a un jugador:
        public void Definir_Heroe(Heroe jug,string nombre, string heroe)
        {
            //Verificando que se haya ingresado un nombre y no sea el mismo del jugador anterior:
            if (TBOnombre.Text == "") { Lporfa.Visibility = Visibility.Visible; }
            if (TBOnombre.Text== jug.enemigo.nombre) { Lporfa2.Visibility = Visibility.Visible; }
            else
            {
                Lporfa.Visibility = Visibility.Hidden;
                Lporfa.Visibility = Visibility.Hidden;
                TBLjugador.Text = "Jugador2";
                TBOnombre.Text = "";

                jug.nombre = nombre;
                List<Carta> tempmazo = new List<Carta>();
                List<string> temphabilidad = new List<string>();
                List<string> tempraza = new List<string>();
                List<int> tempcanthabilidad = new List<int>();
                List<List<Objeto>> tempobjetivos = new List<List<Objeto>>();
                List<string> tempcuando = new List<string>();
                if (nombre == "cazador")
                {
                    jug.descripcion = "Inflige 2 de daño al heroe enemigo";
                    temphabilidad.Add("daña");
                    List<Objeto> tempobjetivo = new List<Objeto>();
                    tempobjetivo.Add(jug.enemigo);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(2);
                    tempcuando.Add(null);
                    tempraza.Add(null);
                }
                else if (nombre == "guerrero")
                {
                    jug.descripcion = "Obtiene 2 de armadura";
                    temphabilidad.Add("suma armadura");
                    List<Objeto> tempobjetivo = new List<Objeto>();
                    tempobjetivo.Add(jug);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(2);
                    tempcuando.Add(null);
                    tempraza.Add(null);
                }
                else if (nombre == "paladin")
                {
                    jug.descripcion = "Invoca un Recluta de la Mano de Plata 1/1";
                    temphabilidad.Add("invoca");
                    List<Objeto> tempobjetivo = new List<Objeto>();
                    Esbirro tempesbirro1 = new Esbirro("Recluta de la Mano de Plata", 0, jug, null, 1, 1, false, false, false, false, false, null, null, null, null, null, null,null);
                    tempobjetivo.Add(jug);
                    tempobjetivo.Add(tempesbirro1);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(1);
                    tempcuando.Add(null);
                    tempraza.Add(null);
                }
                else if (nombre == "rogue")
                {

                }
                jug.mazo = tempmazo;
                jug.objetivo = tempobjetivos;
                jug.habilidades = temphabilidad;
                jug.raza = tempraza;
                jug.canthabilidad = tempcanthabilidad;
                jug.cuando = tempcuando;

                for (int ii = 0; ii <= 2; ii++) { jug.Robar(); }
                coin.Add(jug);


                Esbirro tempesbirro = null;
                //3 wisp:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Wisp", 0, jug, null, 1, 1, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 murloc raider:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Murloc raider", 1, jug, "murloc", 1, 2, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Bloodfen Raptor:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Bloodfen Raptor", 2, jug, "bestia", 2, 3, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 River Crocolist:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("River Crocolist", 2, jug, "bestia", 3, 2, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Magma Rager:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Magma Rager", 3, jug, "elemental", 1, 5, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 ChillWind Yeti:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Chillwind Yeti", 4, jug, null, 5, 4, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Oasis Snapjaw:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Oasis Snapjaw", 4, jug, "bestia", 7, 2, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Boulderfist Ogre:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Boulderfist Ogre", 6, jug, null, 7, 6, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 War Golem:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("War Golem", 7, jug, null, 7, 7, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Core Hound:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Core Hound", 7, jug, "bestia", 5, 9, false, false, false, false, false, null, null, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                jug.mazo = DesordenarLista(jug.mazo);
            }
        }

        //Al estar todo listo, se terminan los preparativos y se pasan los datos a la nueva ventana para luego abrirla:
        public void EmpezarPartida()
        {
            //Seleccionando quien parte:
            Random random = new Random();
            int pri = random.Next(0, 2);
            Heroe primero = coin[pri];
            coin.RemoveAt(pri);
            Heroe segundo = coin[0];


            Partida par = new Partida(primero, segundo);
            par.Show();
            Close();
        }

        //Se prepara la ventana para confirmar


        //Eventos de click al seleccionar héroe:
        private void Bcazador_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { Definir_Heroe(j1, TBOnombre.Text, "cazador"); }
            else
            {
                Definir_Heroe(j2, TBOnombre.Text, "cazador");
                EmpezarPartida();
            }
        }

        private void Bmago_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { Definir_Heroe(j1, TBOnombre.Text, "mago"); }
            else
            {
                Definir_Heroe(j2, TBOnombre.Text, "mago");
                EmpezarPartida();
            }
        }

        private void Brogue_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { Definir_Heroe(j1, TBOnombre.Text, "rogue"); }
            else
            {
                Definir_Heroe(j2, TBOnombre.Text, "rogue");
                EmpezarPartida();
            }
        }

        private void Bbrujo_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { Definir_Heroe(j1, TBOnombre.Text, "brujo"); }
            else
            {
                Definir_Heroe(j2, TBOnombre.Text, "brujo");
                EmpezarPartida();
            }
        }

        private void Bdruida_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { Definir_Heroe(j1, TBOnombre.Text, "druida"); }
            else
            {
                Definir_Heroe(j2, TBOnombre.Text, "druida");
                EmpezarPartida();
            }
        }

        private void Bsacerdote_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { Definir_Heroe(j1, TBOnombre.Text, "sacerdote"); }
            else
            {
                Definir_Heroe(j2, TBOnombre.Text, "sacerdote");
                EmpezarPartida();
            }
        }

        private void Bchaman_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { Definir_Heroe(j1, TBOnombre.Text, "chaman"); }
            else
            {
                Definir_Heroe(j2, TBOnombre.Text, "chaman");
                EmpezarPartida();
            }
        }

        private void Bguerrero_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { Definir_Heroe(j1, TBOnombre.Text, "guerrero"); }
            else
            {
                Definir_Heroe(j2, TBOnombre.Text, "guerrero");
                EmpezarPartida();
            }
        }

        private void Bpaladin_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { Definir_Heroe(j1, TBOnombre.Text, "paladin"); }
            else
            {
                Definir_Heroe(j2, TBOnombre.Text, "paladin");
                EmpezarPartida();
            }
        }

        private void Bvolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            Close();
        }
    }
}
