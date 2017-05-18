using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    public abstract class Carta : Objeto, IObjeto
    {
        //Atributos:
        public string nombre;
        public int costo;
        public Heroe dueño;

        //Métodos que son, en resumen, movimientos entre los contenedores del Héroe:
        virtual public void ActivarCarta()
        {
            dueño.mana -= costo;
            dueño.mano.Remove(this);
        }
        virtual public void Descartar()
        {
            dueño.cementerio.Add(this);
            dueño.mano.Remove(this);
        }
        virtual public void RevivirAMano()
        {
            dueño.mano.Add(this);
            dueño.cementerio.Remove(this);
        }
    }
}
