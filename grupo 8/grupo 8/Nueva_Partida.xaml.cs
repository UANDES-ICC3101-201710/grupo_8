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
    [Serializable]
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
            j1 = new Heroe(null,null,null,null,null,null,null,null,null,null);
            j2 = new Heroe(null,null,null,null,null,null,null,j1,null,null);
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
        public void DefinirHeroe(Heroe jug,string nombre, string heroe)
        {
            //Verificando que se haya ingresado un nombre y no sea el mismo del jugador anterior:
            if (TBOnombre.Text == "") { Lporfa.Visibility = Visibility.Visible; }
            else if (TBOnombre.Text== jug.enemigo.nombre) { Lporfa2.Visibility = Visibility.Visible; }
            else
            {
                //Se modifica la ventana:
                Lporfa.Visibility = Visibility.Hidden;
                Lporfa.Visibility = Visibility.Hidden;
                TBLjugador.Text = "Jugador2";
                TBOnombre.Text = "";

                List<Carta> tempmazo = new List<Carta>();
                List<string> temphabilidad = new List<string>();
                List<int> tempcanthabilidad = new List<int>();
                List<List<Objeto>> tempobjetivos = new List<List<Objeto>>();


                //Se modifica las caracteristicas del heroe según la opción elegida (cambiar imagen para cada uno):
                if (heroe == "cazador")
                {
                    jug.descripcion = "Inflige 2 de daño al heroe enemigo";
                    jug.heroe = "Cazador";
                    temphabilidad.Add("daña");
                    List<Objeto> tempobjetivo = new List<Objeto>();
                    tempobjetivo.Add(jug.enemigo);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(2);
                }
                else if (heroe == "guerrero")
                {
                    jug.descripcion = "Obtiene 2 de armadura";
                    jug.heroe = "Guerrero";
                    temphabilidad.Add("suma armadura");
                    List<Objeto> tempobjetivo = new List<Objeto>();
                    tempobjetivo.Add(jug);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(2);
                }
                else if (heroe == "paladin")
                {
                    jug.heroe = "Paladin";
                    jug.descripcion = "Invoca un Recluta de la Mano de Plata 1/1";
                    temphabilidad.Add("invoca");
                    List<Objeto> tempobjetivo = new List<Objeto>();
                    Esbirro tempesbirro1 = new Esbirro("Recluta de la Mano de Plata",1,jug,1,1,false,null,null,null,null,null); //Cambiar null final por imagen.
                    tempobjetivo.Add(jug);
                    tempobjetivo.Add(tempesbirro1);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(1);
                }
                else if (heroe == "mago")
                {
                    jug.descripcion = "Inflige 1 de daño";
                    jug.heroe = "Mago";
                    temphabilidad.Add("daña");
                    tempcanthabilidad.Add(1);
                }
                else if (heroe == "sacerdote")
                {
                    jug.descripcion = "Restaura 2 de vida";
                    jug.heroe = "Sacerdote";
                    temphabilidad.Add("suma vida");
                    tempcanthabilidad.Add(2);
                }
                else if (heroe == "brujo")
                {
                    jug.descripcion = "Pierdes 2 de vida, roba una carta";
                    jug.heroe = "Brujo";

                    temphabilidad.Add("daña");
                    List<Objeto> tempobjetivo = new List<Objeto>();
                    tempobjetivo.Add(jug);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(2);

                    temphabilidad.Add("roba carta");
                    tempobjetivo = new List<Objeto>();
                    tempobjetivo.Add(jug);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(1);
                }
                else if (heroe == "rogue")
                {
                    jug.heroe = "Pícaro";
                    jug.descripcion = "Equipas una Daga 1/2";
                    temphabilidad.Add("equipa");
                    List<Objeto> tempobjetivo = new List<Objeto>();
                    tempobjetivo.Add(jug);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(2);
                }
                else if (heroe == "druida")
                {
                    jug.heroe = "Druida";
                    jug.descripcion = "Obtienes 1 de ataque y armadura";
                    temphabilidad.Add("druida");
                    List<Objeto> tempobjetivo = new List<Objeto>();
                    tempobjetivo.Add(jug);
                    tempobjetivos.Add(tempobjetivo);
                    tempcanthabilidad.Add(2);
                }

                jug.mazo = tempmazo;
                jug.objetivo = tempobjetivos;
                jug.habilidades = temphabilidad;
                jug.canthabilidad = tempcanthabilidad;
                jug.nombre = nombre;
                //Creando el mazo (cambiar imagen para cada uno):
                Esbirro tempesbirro = null;
                //3 wisp:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Wisp", 0, jug, 1, 1, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 murloc raider:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Murloc raider", 1, jug, 1, 2, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Bloodfen Raptor:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Bloodfen Raptor", 2, jug, 2, 3, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 River Crocolist:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("River Crocolist", 2, jug, 3, 2, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Magma Rager:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Magma Rager", 3, jug,1, 5, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 ChillWind Yeti:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Chillwind Yeti", 4, jug, 5, 4, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Oasis Snapjaw:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Oasis Snapjaw", 4, jug, 7, 2, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Boulderfist Ogre:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Boulderfist Ogre", 6, jug, 7, 6, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 War Golem:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("War Golem", 7, jug, 7, 7, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                //3 Core Hound:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Core Hound", 7, jug, 5, 9, false, null, null, null, null,null);
                    jug.mazo.Add(tempesbirro);
                }
                jug.mazo = DesordenarLista(jug.mazo);
                //Cada jugador roba 3 cartas:
                for (int ii = 0; ii <= 2; ii++) { jug.Robar(); }
                coin.Add(jug);

                if (jug==j1)
                {
                    TBLnj1.Text = jug.nombre;
                    TBLhj1.Text = jug.heroe;
                }

                if (jug==j2)
                {
                    TBLnj2.Text = jug.nombre;
                    TBLhj2.Text = jug.heroe;
                    //Seguro()//
                    EmpezarPartida();
                }
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

            //Ventajas del 2do jugador:
            primero.enemigo.Robar();
            List<string> temphabilidad1 = new List<string>();
            List<int> tempcanthabilidad1 = new List<int>();
            List<List<Objeto>> tempobjetivos1 = new List<List<Objeto>>();
            List<Objeto> tempobjetivo1 = new List<Objeto>();
            temphabilidad1.Add("suma mana");
            tempcanthabilidad1.Add(1);
            tempobjetivo1.Add(primero.enemigo);
            tempobjetivos1.Add(tempobjetivo1);
            Hechizo moneda = new Hechizo("Moneda", 0, primero.enemigo, "Ganas 1 de mana por este turno", temphabilidad1, tempobjetivos1, tempcanthabilidad1, "http://media.pypgamers.com/playhs/cartas/es/513.png");
            primero.enemigo.mano.Add(moneda);

            primero.Iniciarturno();


            Partida par = new Partida(primero);
            par.Show();
            Close();
        }

        //Eventos de click al seleccionar héroe:
        private void Bcazador_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { DefinirHeroe(j1, TBOnombre.Text, "cazador"); }
            else
            {
                DefinirHeroe(j2, TBOnombre.Text, "cazador");
            }
        }

        private void Bmago_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { DefinirHeroe(j1, TBOnombre.Text, "mago"); }
            else{ DefinirHeroe(j2, TBOnombre.Text, "mago"); }
        }

        private void Brogue_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { DefinirHeroe(j1, TBOnombre.Text, "rogue"); }
            else { DefinirHeroe(j2, TBOnombre.Text, "rogue"); }
        }

        private void Bbrujo_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { DefinirHeroe(j1, TBOnombre.Text, "brujo"); }
            else { DefinirHeroe(j2, TBOnombre.Text, "brujo"); }
        }

        private void Bdruida_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { DefinirHeroe(j1, TBOnombre.Text, "druida"); }
            else { DefinirHeroe(j2, TBOnombre.Text, "druida"); }
        }

        private void Bsacerdote_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { DefinirHeroe(j1, TBOnombre.Text, "sacerdote"); }
            else { DefinirHeroe(j2, TBOnombre.Text, "sacerdote"); }
        }

        private void Bguerrero_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { DefinirHeroe(j1, TBOnombre.Text, "guerrero"); }
            else { DefinirHeroe(j2, TBOnombre.Text, "guerrero"); }
        }

        private void Bpaladin_Click(object sender, RoutedEventArgs e)
        {
            if (TBLjugador.Text == "Jugador1") { DefinirHeroe(j1, TBOnombre.Text, "paladin"); }
            else { DefinirHeroe(j2, TBOnombre.Text, "paladin"); }
        }

        //Evento para volver al menú anterior:
        private void Bvolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            Close();
        }
    }
}
