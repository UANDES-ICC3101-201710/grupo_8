using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneProject
{
    public class Esbirro : Carta, IVivos
    {
        //Atributos agregados, propios de Esbirro:
        public string tipo;     //Indica de que raza es. Afecta para cuando se use una habilidad.
        public int maxvidaor;   //la terminacion "-or" indica el valor original. Este no debería cambiar en todo el juego. Se usa cuando revive o se devuelve a la mano.
        public int ataqueor;
        public int vida;
        public int maxvida;     //vida y maxvida hace la diferencia cuando se usa la habilidad "suma vida" o "suma maxvida". Ej: "Restaura 2 de vida a un aliado" no afecta max vida.
        public int ataque;
        public int atacar;      //Indica si puede atacar en el turno. -1 para congelado, 0 que no puede y 1 que sí.
        public bool provocacion;
        public bool veneno;
        public bool viento;
        public bool escudo;
        public bool sigilo;
        public bool inmune;

        //Constructor:
        public Esbirro(string nombre, int costo, Heroe dueño, string tipo, int vida, int ataque, bool provocacion, bool veneno, bool viento, bool escudo, bool sigilo, List<string> habilidades, List<List<Objeto>> objetivo, List<string> raza, List<int> canthabilidad, List<string> cuando, string descripcion)
        {
            this.habilidades = habilidades;
            this.objetivo = objetivo;
            this.raza = raza;
            this.canthabilidad = canthabilidad;
            this.cuando = cuando;
            this.descripcion = descripcion;
            this.nombre = nombre;
            this.costo = costo;
            this.dueño = dueño;
            this.tipo = tipo;
            this.vida = maxvida = maxvidaor = vida;
            this.ataque = ataqueor = ataque;
            atacar = 0;
            this.provocacion = provocacion;
            this.veneno = veneno;
            this.viento = viento;
            this.escudo = escudo;
            this.sigilo = sigilo;
        }


        //Métodos:

        //Actualizado:
        public override void ActivarCarta()
        {
            base.ActivarCarta();
            dueño.campo.Add(this);
            ActivarHabilidades("grito de batalla");
        }

        //Metodos propios de los vivos (IVivos)
        public void Atacar(Objeto objetivo)
        {
            ActivarHabilidades("al atacar");
            if (objetivo is Heroe heroe)
            {
                heroe.RecibirDaño(ataque);
            }
            else if (objetivo is Esbirro esbirro)
            {
                esbirro.RecibirDaño(ataque);
                RecibirDaño(esbirro.ataque);
            }
            atacar = 0;
        }
        public void RecibirDaño(int daño)
        {
            ActivarHabilidades("al recibir daño");
            if (escudo) { escudo = false; }
            else
            {
                vida -= daño;
                if (vida <= 0) { Morir(); }
            }
        }

        //movimiento de contenedores y restablece atributos:
        public void Morir()
        {
            ActivarHabilidades("estertor");
            dueño.cementerio.Add(this);
            dueño.campo.Remove(this);
            vida = maxvida = maxvidaor;
            ataque = ataqueor;
            atacar = 0;
        }
    }
}

