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
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace HearthstoneProject
{
    /// <summary>
    /// Lógica de interacción para Partida.xaml
    /// </summary>
    [Serializable]
    public partial class Partida : Window
    {
        Heroe jugador; //El jugador del turno (irá cambiando)
        //Atributos que guardaran los controles dependiendo de su funcion (sirve para ActualizarVentana() ):
        List<Button> imano;
        List<Label> amano;
        List<Label> vmano;
        List<Label> cmano;
        List<Button> icampo;
        List<Label> acampo;
        List<Label> vcampo;
        List<Rectangle> rcampo;
        List<Button> icenemigo;
        List<Label> acenemigo;
        List<Label> vcenemigo;
        List<Image> imenemigo;
        public Partida(Heroe jug1)
        {
            jugador = jug1;

            InitializeComponent();
            //Escondiendo los controles que no aparecen al partir:
            Icm1.Visibility = Visibility.Hidden;
            Icm2.Visibility = Visibility.Hidden;
            Icm3.Visibility = Visibility.Hidden;
            Icm4.Visibility = Visibility.Hidden;
            Icm5.Visibility = Visibility.Hidden;
            Icm6.Visibility = Visibility.Hidden;
            Icm7.Visibility = Visibility.Hidden;
            Icm8.Visibility = Visibility.Hidden;
            Icm9.Visibility = Visibility.Hidden;
            Icm10.Visibility = Visibility.Hidden;
            Icb1.Visibility = Visibility.Hidden;
            Icb2.Visibility = Visibility.Hidden;
            Icb3.Visibility = Visibility.Hidden;
            Icb4.Visibility = Visibility.Hidden;
            Icb5.Visibility = Visibility.Hidden;
            Icb6.Visibility = Visibility.Hidden;
            Icb7.Visibility = Visibility.Hidden;
            Ice1.Visibility = Visibility.Hidden;
            Ice2.Visibility = Visibility.Hidden;
            Ice3.Visibility = Visibility.Hidden;
            Ice4.Visibility = Visibility.Hidden;
            Ice5.Visibility = Visibility.Hidden;
            Ice6.Visibility = Visibility.Hidden;
            Ice7.Visibility = Visibility.Hidden;
            Icme1.Visibility = Visibility.Hidden;
            Icme2.Visibility = Visibility.Hidden;
            Icme3.Visibility = Visibility.Hidden;
            Icme4.Visibility = Visibility.Hidden;
            Icme5.Visibility = Visibility.Hidden;
            Icme6.Visibility = Visibility.Hidden;
            Icme7.Visibility = Visibility.Hidden;
            Icme8.Visibility = Visibility.Hidden;
            Icme9.Visibility = Visibility.Hidden;
            Icme10.Visibility = Visibility.Hidden;
            cm1costo.Visibility = Visibility.Hidden;
            cm2costo.Visibility = Visibility.Hidden;
            cm3costo.Visibility = Visibility.Hidden;
            cm4costo.Visibility = Visibility.Hidden;
            cm5costo.Visibility = Visibility.Hidden;
            cm6costo.Visibility = Visibility.Hidden;
            cm7costo.Visibility = Visibility.Hidden;
            cm8costo.Visibility = Visibility.Hidden;
            cm9costo.Visibility = Visibility.Hidden;
            cm10costo.Visibility = Visibility.Hidden;
            cm1vida.Visibility = Visibility.Hidden;
            cm2vida.Visibility = Visibility.Hidden;
            cm3vida.Visibility = Visibility.Hidden;
            cm4vida.Visibility = Visibility.Hidden;
            cm5vida.Visibility = Visibility.Hidden;
            cm6vida.Visibility = Visibility.Hidden;
            cm7vida.Visibility = Visibility.Hidden;
            cm8vida.Visibility = Visibility.Hidden;
            cm9vida.Visibility = Visibility.Hidden;
            cm10vida.Visibility = Visibility.Hidden;
            cb1vida.Visibility = Visibility.Hidden;
            cb2vida.Visibility = Visibility.Hidden;
            cb3vida.Visibility = Visibility.Hidden;
            cb4vida.Visibility = Visibility.Hidden;
            cb5vida.Visibility = Visibility.Hidden;
            cb6vida.Visibility = Visibility.Hidden;
            cb7vida.Visibility = Visibility.Hidden;
            ce1vida.Visibility = Visibility.Hidden;
            ce2vida.Visibility = Visibility.Hidden;
            ce3vida.Visibility = Visibility.Hidden;
            ce4vida.Visibility = Visibility.Hidden;
            ce5vida.Visibility = Visibility.Hidden;
            ce6vida.Visibility = Visibility.Hidden;
            ce7vida.Visibility = Visibility.Hidden;
            cm1ataque.Visibility = Visibility.Hidden;
            cm2ataque.Visibility = Visibility.Hidden;
            cm3ataque.Visibility = Visibility.Hidden;
            cm4ataque.Visibility = Visibility.Hidden;
            cm5ataque.Visibility = Visibility.Hidden;
            cm6ataque.Visibility = Visibility.Hidden;
            cm7ataque.Visibility = Visibility.Hidden;
            cm8ataque.Visibility = Visibility.Hidden;
            cm9ataque.Visibility = Visibility.Hidden;
            cm10ataque.Visibility = Visibility.Hidden;
            cb1ataque.Visibility = Visibility.Hidden;
            cb2ataque.Visibility = Visibility.Hidden;
            cb3ataque.Visibility = Visibility.Hidden;
            cb4ataque.Visibility = Visibility.Hidden;
            cb5ataque.Visibility = Visibility.Hidden;
            cb6ataque.Visibility = Visibility.Hidden;
            cb7ataque.Visibility = Visibility.Hidden;
            ce1ataque.Visibility = Visibility.Hidden;
            ce2ataque.Visibility = Visibility.Hidden;
            ce3ataque.Visibility = Visibility.Hidden;
            ce4ataque.Visibility = Visibility.Hidden;
            ce5ataque.Visibility = Visibility.Hidden;
            ce6ataque.Visibility = Visibility.Hidden;
            ce7ataque.Visibility = Visibility.Hidden;
            a1ataque.Visibility = Visibility.Hidden;
            a2ataque.Visibility = Visibility.Hidden;
            a1duracion.Visibility = Visibility.Hidden;
            a2duracion.Visibility = Visibility.Hidden;
            Ia1.Visibility = Visibility.Hidden;
            Ia2.Visibility = Visibility.Hidden;
            Rc1.Visibility = Visibility.Hidden;
            Rc2.Visibility = Visibility.Hidden;
            Rc3.Visibility = Visibility.Hidden;
            Rc4.Visibility = Visibility.Hidden;
            Rc5.Visibility = Visibility.Hidden;
            Rc6.Visibility = Visibility.Hidden;
            Rc7.Visibility = Visibility.Hidden;
            Rc8.Visibility = Visibility.Hidden;
            Rc9.Visibility = Visibility.Hidden;
            Lseleccion.Visibility = Visibility.Hidden;
            habusada.Visibility = Visibility.Hidden;
            nomana.Visibility = Visibility.Hidden;
            Lyaatacar.Visibility = Visibility.Hidden;
            Lmalseleccion.Visibility = Visibility.Hidden;
            Lyaatacar2.Visibility = Visibility.Hidden;
            //Agregando los controles a las listas atributos:
            imano = new List<Button>();
            amano = new List<Label>();
            vmano = new List<Label>();
            cmano = new List<Label>();
            icampo = new List<Button>();
            acampo = new List<Label>();
            vcampo = new List<Label>();
            icenemigo = new List<Button>();
            acenemigo = new List<Label>();
            vcenemigo = new List<Label>();
            imenemigo = new List<Image>();
            rcampo = new List<Rectangle>();
            imano.Add(Icm1);
            imano.Add(Icm2);
            imano.Add(Icm3);
            imano.Add(Icm4);
            imano.Add(Icm5);
            imano.Add(Icm6);
            imano.Add(Icm7);
            imano.Add(Icm8);
            imano.Add(Icm9);
            imano.Add(Icm10);
            icampo.Add(Icb1);
            icampo.Add(Icb2);
            icampo.Add(Icb3);
            icampo.Add(Icb4);
            icampo.Add(Icb5);
            icampo.Add(Icb6);
            icampo.Add(Icb7);
            icenemigo.Add(Ice1);
            icenemigo.Add(Ice2);
            icenemigo.Add(Ice3);
            icenemigo.Add(Ice4);
            icenemigo.Add(Ice5);
            icenemigo.Add(Ice6);
            icenemigo.Add(Ice7);
            imenemigo.Add(Icme1);
            imenemigo.Add(Icme2);
            imenemigo.Add(Icme3);
            imenemigo.Add(Icme4);
            imenemigo.Add(Icme5);
            imenemigo.Add(Icme6);
            imenemigo.Add(Icme7);
            imenemigo.Add(Icme8);
            imenemigo.Add(Icme9);
            imenemigo.Add(Icme10);
            amano.Add(cm1ataque);
            amano.Add(cm2ataque);
            amano.Add(cm3ataque);
            amano.Add(cm4ataque);
            amano.Add(cm5ataque);
            amano.Add(cm6ataque);
            amano.Add(cm7ataque);
            amano.Add(cm8ataque);
            amano.Add(cm9ataque);
            amano.Add(cm10ataque);
            acampo.Add(cb1ataque);
            acampo.Add(cb2ataque);
            acampo.Add(cb3ataque);
            acampo.Add(cb4ataque);
            acampo.Add(cb5ataque);
            acampo.Add(cb6ataque);
            acampo.Add(cb7ataque);
            acenemigo.Add(ce1ataque);
            acenemigo.Add(ce2ataque);
            acenemigo.Add(ce3ataque);
            acenemigo.Add(ce4ataque);
            acenemigo.Add(ce5ataque);
            acenemigo.Add(ce6ataque);
            acenemigo.Add(ce7ataque);
            vcenemigo.Add(ce1vida);
            vcenemigo.Add(ce2vida);
            vcenemigo.Add(ce3vida);
            vcenemigo.Add(ce4vida);
            vcenemigo.Add(ce5vida);
            vcenemigo.Add(ce6vida);
            vcenemigo.Add(ce7vida);
            vcenemigo.Add(ce1vida);
            vcampo.Add(cb1vida);
            vcampo.Add(cb2vida);
            vcampo.Add(cb3vida);
            vcampo.Add(cb4vida);
            vcampo.Add(cb5vida);
            vcampo.Add(cb6vida);
            vcampo.Add(cb7vida);
            vmano.Add(cm1vida);
            vmano.Add(cm2vida);
            vmano.Add(cm3vida);
            vmano.Add(cm4vida);
            vmano.Add(cm5vida);
            vmano.Add(cm6vida);
            vmano.Add(cm7vida);
            vmano.Add(cm8vida);
            vmano.Add(cm9vida);
            vmano.Add(cm10vida);
            cmano.Add(cm1costo);
            cmano.Add(cm2costo);
            cmano.Add(cm3costo);
            cmano.Add(cm4costo);
            cmano.Add(cm5costo);
            cmano.Add(cm6costo);
            cmano.Add(cm7costo);
            cmano.Add(cm8costo);
            cmano.Add(cm9costo);
            cmano.Add(cm10costo);
            rcampo.Add(Rc1);
            rcampo.Add(Rc2);
            rcampo.Add(Rc3);
            rcampo.Add(Rc4);
            rcampo.Add(Rc5);
            rcampo.Add(Rc6);
            rcampo.Add(Rc7);
            rcampo.Add(Rc8);
            rcampo.Add(Rc9);
            ActualizarVentana();
        }

        //Método para actualizar datos y controles de la ventana segun jugador actual:
        public void ActualizarVentana()
        {
            Lturno.Content = "Tu turno,";
            Lturno2.Content = jugador.nombre;

            //Datos del heroe:
            heroej.Content = jugador.nombre;
            Ldescripcion.Content = jugador.descripcion;
            h1vida.Content = Convert.ToString(jugador.vida);
            if (jugador.armadura > 0)
            {
                h1armadura.Visibility = Visibility.Visible;
                h1armadura.Content = Convert.ToString(jugador.armadura);
            }
            else { h1armadura.Visibility = Visibility.Hidden; }
            if (jugador.ataque > 0)
            {
                a1ataque.Visibility = Visibility.Visible;
                if (jugador.heroe!="Druida")
                {
                    a1duracion.Visibility = Visibility.Visible;
                }
                Ia1.Visibility = Visibility.Visible;
                a1ataque.Content = Convert.ToString(jugador.ataque);
                a1duracion.Content = Convert.ToString(jugador.duracion);
            }
            else
            {
                a1ataque.Visibility = Visibility.Hidden;
                a1duracion.Visibility = Visibility.Hidden;
                Ia1.Visibility = Visibility.Hidden;
            }
            mana.Content = Convert.ToString(jugador.mana);
            maxmana.Content = Convert.ToString(jugador.maxmana);

            //Datos del heroe enemigo:
            heroee.Content = jugador.enemigo.nombre;
            h2vida.Content = Convert.ToString(jugador.enemigo.vida);
            if (jugador.enemigo.armadura > 0)
            {
                h2armadura.Visibility = Visibility.Visible;
                h2armadura.Content = Convert.ToString(jugador.enemigo.armadura);
            }
            else { h2armadura.Visibility = Visibility.Hidden; }
            if (jugador.enemigo.ataque > 0)
            {
                a2ataque.Visibility = Visibility.Visible;
                a2duracion.Visibility = Visibility.Visible;
                Ia2.Visibility = Visibility.Visible;
                a2ataque.Content = Convert.ToString(jugador.enemigo.ataque);
                a2duracion.Content = Convert.ToString(jugador.enemigo.duracion);
            }
            else
            {
                a2ataque.Visibility = Visibility.Hidden;
                a2duracion.Visibility = Visibility.Hidden;
                Ia2.Visibility = Visibility.Hidden;
            }

            int i = 0;
            //Cartas de la mano:
            foreach (Carta carta in jugador.mano)
            {

                //(Transformacion de string de direccion de imagen a source de imagen sacada por internet):
                //BitmapImage image = new BitmapImage(new Uri(carta.imagen, UriKind.Relative));
                //imano[i].Source = image;
                imano[i].Content = carta.nombre;
                imano[i].Visibility = Visibility.Visible;

                //modificando los labels para indicar costo, ataque, vida, etc:
                cmano[i].Content = Convert.ToString(carta.costo);
                if (carta is Esbirro esbirro)
                {
                    amano[i].Content = Convert.ToString(esbirro.ataque);
                    vmano[i].Content = Convert.ToString(esbirro.vida);
                    amano[i].Visibility = Visibility.Visible;
                    vmano[i].Visibility = Visibility.Visible;
                }
                if (carta is Arma arma)
                {
                    amano[i].Content = Convert.ToString(arma.ataque);
                    vmano[i].Content = Convert.ToString(arma.duracion);
                    amano[i].Visibility = Visibility.Visible;
                    vmano[i].Visibility = Visibility.Visible;
                }
                imano[i].Visibility = Visibility.Visible;
                cmano[i].Visibility = Visibility.Visible;
                i++;
            }
            while (i < imano.Count)
            {
                imano[i].Visibility = Visibility.Hidden;
                amano[i].Visibility = Visibility.Hidden;
                vmano[i].Visibility = Visibility.Hidden;
                cmano[i].Visibility = Visibility.Hidden;
                TBox.Visibility = Visibility.Hidden;
                Larchivo.Visibility = Visibility.Hidden;
                i++;
            }

            i = 0;
            //Esbirros en el campo:
            foreach (Esbirro esbirro in jugador.campo)
            {
                //BitmapImage image = new BitmapImage(new Uri(esbirro.imagen, UriKind.Relative));
                //icampo[i].Source = image;
                icampo[i].Visibility = Visibility.Visible;
                acampo[i].Visibility = Visibility.Visible;
                vcampo[i].Visibility = Visibility.Visible;
                icampo[i].Content = esbirro.nombre;
                acampo[i].Content = Convert.ToString(esbirro.ataque);
                vcampo[i].Content = Convert.ToString(esbirro.vida);
                if (esbirro.vida < esbirro.maxvida)
                {
                    vcampo[i].Foreground = Brushes.Orange;
                }
                else
                {
                    vcampo[i].Foreground = Brushes.White;
                }
                i++;
            }
            while (i < icampo.Count)
            {
                icampo[i].Visibility = Visibility.Hidden;
                acampo[i].Visibility = Visibility.Hidden;
                vcampo[i].Visibility = Visibility.Hidden;
                i++;
            }

            i = 0;
            //Esbirros en el campo enemigo:
            foreach (Esbirro esbirro in jugador.enemigo.campo)
            {
                //BitmapImage image = new BitmapImage(new Uri(esbirro.imagen, UriKind.Relative));
                //icenemigo[i].Source = image;
                icenemigo[i].Content = esbirro.nombre;
                icenemigo[i].Visibility = Visibility.Visible;
                acenemigo[i].Visibility = Visibility.Visible;
                vcenemigo[i].Visibility = Visibility.Visible;

                acenemigo[i].Content = Convert.ToString(esbirro.ataque);
                vcenemigo[i].Content = Convert.ToString(esbirro.vida);
                if (esbirro.vida < esbirro.maxvida)
                {
                    vcenemigo[i].Foreground = Brushes.Orange;
                }
                else
                {
                    vcampo[i].Foreground = Brushes.White;
                }
                i++;
            }
            while (i < icenemigo.Count)
            {
                icenemigo[i].Visibility = Visibility.Hidden;
                acenemigo[i].Visibility = Visibility.Hidden;
                vcenemigo[i].Visibility = Visibility.Hidden;
                i++;
            }

            i = 0;
            //Mostrando la cantidad de cartas del enemigo, sin mostrar cuales son:
            foreach (Carta carta in jugador.enemigo.mano)
            {
                imenemigo[i].Visibility = Visibility.Visible;
            }
            while (i < imenemigo.Count)
            {
                imenemigo[i].Visibility = Visibility.Hidden;
                i++;
            }

            //escondiendo errores:
            habusada.Visibility = Visibility.Hidden;
            nomana.Visibility = Visibility.Hidden;
            Lseleccion.Visibility = Visibility.Hidden;
            Lyaatacar.Visibility = Visibility.Hidden;
            Lmalseleccion.Visibility = Visibility.Hidden;
            Lyaatacar2.Visibility = Visibility.Hidden;

            foreach (Rectangle rec in rcampo)
            {
                rec.Visibility = Visibility.Hidden;
            }

            if (jugador.vida <= 0)
            {
                Ganaste g = new Ganaste(jugador.enemigo);
                g.Show();
                Close();
            }
            else if (jugador.enemigo.vida <= 0)
            {
                Ganaste g = new Ganaste(jugador);
                g.Show();
                Close();
            }
        }

        //Método que revisa cuál rectangulo se esta mostrando (Que carta o habilidad se va a usar), y si no hay devuelve -1:
        public int RevisarCualRectangulo()
        {
            foreach (Rectangle rectangulo in rcampo)
            {
                if (rectangulo.Visibility == Visibility.Visible)
                {
                    return rcampo.IndexOf(rectangulo);
                }
            }
            return -1;
        }

        //Eventos de botones:
        private void Blisto_Click(object sender, RoutedEventArgs e)
        {
            jugador.Terminarturno();
            jugador = jugador.enemigo;
            jugador.Iniciarturno();
            ActualizarVentana();
        }
        private void Bhabilidad_Click(object sender, RoutedEventArgs e)
        {
            //Si ya se estaba eligiendo objetivo de ataque, se muestra error:
            if (RevisarCualRectangulo() > -1 && RevisarCualRectangulo() != 7) { Lmalseleccion.Visibility = Visibility.Visible; }
            //Si ya se estaba eligiendo objetivo de habilidad, se cancela:
            else if (RevisarCualRectangulo() == 7)
            {
                Lseleccion.Visibility = Visibility.Hidden;
                Rc8.Visibility = Visibility.Hidden;
            }
            //Si no, se activa:
            else
            {
                if (!jugador.puedehabilidad)
                {
                    habusada.Visibility = Visibility.Visible;
                }
                if (jugador.mana < 2)
                {
                    nomana.Visibility = Visibility.Visible;
                }
                else if (jugador.puedehabilidad)
                {
                    if (jugador.objetivo.Count == 0)
                    {
                        Rc8.Visibility = Visibility.Visible;
                        Lseleccion.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        jugador.UsarHabilidad();
                        ActualizarVentana();
                    }
                }
            }
        }

        private void Icm_Click(object sender, RoutedEventArgs e)
        {
            Carta carta = jugador.mano[imano.IndexOf((Button)sender)];

            //Si no es seleccionado como objetivo, se activa la carta:
            if (RevisarCualRectangulo() == -1)
            {
                //Si el jugador no tiene suficiente mana, error:
                if (jugador.mana < carta.costo)
                {
                    nomana.Visibility = Visibility.Visible;
                }
                //Si tiene, activa la carta:
                else
                {
                    carta.ActivarCarta();
                    ActualizarVentana();
                }
            }

            //Si es seleccionado como objetivo, error:
            else
            {
                Lmalseleccion.Visibility = Visibility.Visible;
            }
        }
        private void Icb_Click(object sender, RoutedEventArgs e)
        {
            //Guardando datos relacionados con el boton:
            Rectangle rectangulo = rcampo[icampo.IndexOf((Button)sender)];

            //Revisando si ya se esta eligiendo objetivo:
            //Si no, se activa para elegir objetivo de ataque:
            if (RevisarCualRectangulo() == -1)
            {
                if (jugador.campo[icampo.IndexOf((Button)sender)].atacar < 1)
                {
                    Lyaatacar.Visibility = Visibility.Visible;
                }
                else
                {
                    rectangulo.Visibility = Visibility.Visible;
                    Lseleccion.Visibility = Visibility.Visible;
                }
            }
            //Si ya se estaba eligiendo y era su propio objetivo, se cancela:
            else if (rectangulo.Visibility == Visibility.Visible)
            {
                rectangulo.Visibility = Visibility.Hidden;
                Lseleccion.Visibility = Visibility.Hidden;
            }
            //Si era objetivo del heroe o de esbirro amigo, error:
            else if (RevisarCualRectangulo() != 7)
            {
                Lmalseleccion.Visibility = Visibility.Visible;
            }
            //Si es objetivo de habilidad, se efectua:
            else
            {
                List<Objeto> templist = new List<Objeto>();
                templist.Add(jugador.campo[icampo.IndexOf((Button)sender)]);
                jugador.objetivo.Add(templist);
                jugador.UsarHabilidad();
                jugador.objetivo.Remove(templist);
                ActualizarVentana();
            }
        }

        private void Ice_Click(object sender, RoutedEventArgs e)
        {
            //Si es objetivo de habilidad, se efectua sobre él:
            if (RevisarCualRectangulo() == 7)
            {
                List<Objeto> templist = new List<Objeto>();
                templist.Add(jugador.enemigo.campo[icenemigo.IndexOf((Button)sender)]);
                jugador.objetivo.Add(templist);
                jugador.UsarHabilidad();
                jugador.objetivo.Remove(templist);
            }
            //Si es objetivo de ataque de heroe, se efectua sobre él:
            else if (RevisarCualRectangulo() == 8)
            {
                jugador.Atacar(jugador.enemigo.campo[icenemigo.IndexOf((Button)sender)]);
            }
            //Si es objetivo de ataque de esbirro:
            else if (RevisarCualRectangulo() != -1)
            {
                jugador.campo[RevisarCualRectangulo()].Atacar(jugador.enemigo.campo[icenemigo.IndexOf((Button)sender)]);
            }
            ActualizarVentana();
            ActualizarVentana();
        }

        private void heroej_Click(object sender, RoutedEventArgs e)
        {
            //Si no se esta seleccionando objetivo, se empieza a elegir objetivo para ataque:
            if (RevisarCualRectangulo() == -1)
            {
                if (jugador.ataque > 0)
                {
                    if (jugador.puedeatacar > 0)
                    {
                        Rc9.Visibility = Visibility.Visible;
                        Lseleccion.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        Lyaatacar2.Visibility = Visibility.Visible;
                    }
                }
            }
            //Si se estaba eligiendo objetivo de habilidad, se activa:
            else if (RevisarCualRectangulo() == 7)
            {
                List<Objeto> templist = new List<Objeto>();
                templist.Add(jugador);
                jugador.objetivo.Add(templist);
                jugador.UsarHabilidad();
                jugador.objetivo.Remove(templist);
                ActualizarVentana();
            }
            //Si ya se estaba eligiendo objetivo de ataque de heroe, se cancela:
            else if (RevisarCualRectangulo() == 8)
            {
                ActualizarVentana();
            }
            //Si se estaba eligiendo objetivo de ataque de esbirro, error:
            else
            {
                Lmalseleccion.Visibility = Visibility.Visible;
            }
        }
        private void heroee_Click(object sender, RoutedEventArgs e)
        {
            //Si es objetivo del heroe, es atacado:
            if (RevisarCualRectangulo() == 8)
            {
                jugador.Atacar(jugador.enemigo);
            }
            //Si es objetivo de habilidad, se activa:
            else if (RevisarCualRectangulo() == 7)
            {
                List<Objeto> templist = new List<Objeto>();
                templist.Add(jugador.enemigo);
                jugador.objetivo.Add(templist);
                jugador.UsarHabilidad();
                jugador.objetivo.Remove(templist);
            }
            //Si es objetivo de Esbirro, es atacado:
            else if (RevisarCualRectangulo() != -1)
            {
                jugador.campo[RevisarCualRectangulo()].Atacar(jugador.enemigo);
            }
            ActualizarVentana();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (TBox.Visibility == Visibility.Hidden)
            {
                TBox.Visibility = Visibility.Visible;
                Larchivo.Visibility = Visibility.Visible;
                TBox.Text = "";
            }
            else if (TBox.Text!="")
            {
                SaveGame(jugador, TBox.Text);
                ActualizarVentana();
            }
        }
        private static void SaveGame(Heroe jugador, string nombrePartida)
        {
            //Nombre del archivo a guardar cambiar el readLine, por un nombre cualquiera
            string fileName = nombrePartida;
            // Creamos el Stream donde guardaremos nuestro juego
            FileStream fs = new FileStream(fileName, FileMode.CreateNew);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, jugador);
            fs.Close();
        }
    }
}
