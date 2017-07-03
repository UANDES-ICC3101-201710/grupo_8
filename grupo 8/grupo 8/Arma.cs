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
        public Arma(string nombre, int costo, Heroe dueño, int ataque, int duracion, string descripcion,string imagen)
        {
            this.descripcion = descripcion;
            this.nombre = nombre;
            this.costo = costo;
            this.dueño = dueño;
            this.ataque = ataque;
            this.duracion = duracion;
            this.imagen = imagen;
        }

        //Método actualizado para Arma:
        public override void ActivarCarta()
        {
            base.ActivarCarta();
            dueño.ataque = ataque;
            dueño.duracion = duracion;
            dueño.mana -= costo;
            dueño.cementerio.Add(this);
            dueño.puedeatacar = 1;
        }
    }
}