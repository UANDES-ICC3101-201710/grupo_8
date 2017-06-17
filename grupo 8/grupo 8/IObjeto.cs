using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneProject
{
    interface IObjeto
    {
        //Se creo esta clase para que no haya acoplamiento. Lo que hace Habilidad esta explicado en Objeto.
        void Habilidad(string habilidad, int x, List<Objeto> objetivos, string tipo);
    }
}