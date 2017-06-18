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
        //Atributos que guardaran los controles dependiendo de su funcion (sirve para ActualizarVentana() ):
        List<Image> imano;
        List<Label> amano;
        List<Label> vmano;
        List<Label> cmano;
        List<Image> icampo;
        List<Label> acampo;
        List<Label> vcampo;
        List<Image> icenemigo;
        List<Label> acenemigo;
        List<Label> vcenemigo;
        List<Image> imenemigo;
        public Partida(Heroe jug1, Heroe jug2)
        {
            jugador1 = jug1;
            jugador2 = jug2;
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
            //Agregando los controles a las listas atributos:
            imano = new List<Image>();
            amano = new List<Label>();
            vmano = new List<Label>();
            cmano = new List<Label>();
            icampo = new List<Image>();
            acampo = new List<Label>();
            vcampo = new List<Label>();
            icenemigo = new List<Image>();
            acenemigo = new List<Label>();
            vcenemigo = new List<Label>();
            imenemigo = new List<Image>();
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
            ActualizarVentana(jugador1);
        }

        //Método para actualizar datos y controles de la ventana segun jugador actual:
        public void ActualizarVentana(Heroe jactual)
        {
            
            int i = 0;
            //Cartas de la mano:
            foreach (Carta carta in jactual.mano)
            {

                //(Transformacion de string de direccion de imagen a source de imagen sacada por internet):
                //BitmapImage image = new BitmapImage(new Uri(carta.imagen, UriKind.Relative));
                //imano[i].Source = image;

                //modificando los labels para indicar costo, ataque, vida, etc:
                cmano[i].Content = Convert.ToString(carta.costo);
                if (carta is Esbirro esbirro)
                {
                    amano[i].Content = Convert.ToString(esbirro.ataque);
                    vmano[i].Content = Convert.ToString(esbirro.vida);
                }
                if (carta is Arma arma)
                {
                    amano[i].Content = Convert.ToString(arma.ataque);
                    vmano[i].Content = Convert.ToString(arma.duracion);
                }
                imano[i].Visibility = Visibility.Visible;
                amano[i].Visibility = Visibility.Visible;
                vmano[i].Visibility = Visibility.Visible;
                cmano[i].Visibility = Visibility.Visible;
                i++;
            }

            //Esbirros en el campo
            i = 0;
            foreach (Esbirro esbirro in jactual.campo)
            {
                //BitmapImage image = new BitmapImage(new Uri(esbirro.imagen, UriKind.Relative));
                //imano[i].Source = image;
            }
        }
    }
}
