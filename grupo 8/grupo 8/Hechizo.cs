using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneProject
{
    [Serializable]
    class Hechizo : Carta
    {
        //Constructor:
        public Hechizo(string nombre, int costo, Heroe dueño, string descripcion, List<string> habilidades, List<List<Objeto>> objetivo, List<int> canthabilidad,string imagen)
        {
            this.descripcion = descripcion;
            this.habilidades = habilidades;
            this.objetivo = objetivo;
            this.canthabilidad = canthabilidad;
            this.nombre = nombre;
            this.costo = costo;
            this.dueño = dueño;
            this.imagen = imagen;
        }

        //Método actualizado para Hechizo:
        public override void ActivarCarta()
        {
            base.ActivarCarta();
            dueño.cementerio.Add(this);
            ActivarHabilidades(null);
        }
    }
}