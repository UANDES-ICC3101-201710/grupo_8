using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneProject
{
    class Hechizo : Carta
    {
        //Constructor:
        public Hechizo(string nombre, int costo, Heroe dueño, string descripcion, List<string> habilidades, List<List<Objeto>> objetivo, List<string> raza, List<int> canthabilidad, List<string> cuando)
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