using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneProject
{
    class Arma : Carta
    {
        //Atributos agregados, propios de Arma:
        public int ataque;
        public int duracion;

        //Constructor:
        public Arma(string nombre, int costo, Heroe dueño, int ataque, int duracion, List<string> habilidades, List<List<Objeto>> objetivo, List<string> raza, List<int> canthabilidad, List<string> cuando, string descripcion)
        {
            this.descripcion = descripcion;
            this.habilidades = habilidades;
            this.objetivo = objetivo;
            this.raza = raza;
            this.canthabilidad = canthabilidad;
            this.cuando = cuando;
            this.nombre = nombre;
            this.costo = costo;
            this.dueño = dueño;
            this.ataque = ataque;
            this.duracion = duracion;
        }

        //Método actualizado para Arma:
        public override void ActivarCarta()
        {
            ActivarHabilidades("grito de batalla");
            base.ActivarCarta();
            dueño.ataque = ataque;
            dueño.duracion = duracion;
            dueño.mana -= costo;
            dueño.cementerio.Add(this);
            dueño.puedeatacar = 1;
        }
    }
}