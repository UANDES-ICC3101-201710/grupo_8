using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneProject
{
    [Serializable]
    public abstract class Objeto : IObjeto
    {
        //Todas nuestras clases tienen la posibilidad de tener habilidades, esta es la razón de la creación de esta clase.

        public List<string> habilidades;
        public List<List<Objeto>> objetivo; //los objetivos pueden ser Esbirro o Héroe.
        public List<int> canthabilidad;     //Cuanto afectará al objetivo
        public string descripcion;          //Un resumen de que hacen todas las habilidades.
        public string imagen;

        //Este método activa un efecto de habilidad:
        public virtual void Habilidad(string habilidad, int x, List<Objeto> objetivos)
        {
            if (habilidad != null)
            {
                foreach (Objeto objetivo in objetivos)
                {
                    if (objetivo is Heroe heroe)
                    {
                        if (habilidad == "invoca")
                        {
                            for (int i = 0; i < x; i++)
                            {
                                Esbirro invocado = (Esbirro)objetivos[1];
                                (objetivos[0] as Heroe).campo.Add(new Esbirro(invocado.nombre, invocado.costo, invocado.dueño, invocado.vida, invocado.ataque, invocado.provocacion, invocado.habilidades, invocado.objetivo, invocado.canthabilidad, invocado.descripcion, invocado.imagen));
                            }
                        }
                        else if (habilidad == "daña")
                        {
                            heroe.RecibirDaño(x);
                        }
                        else if (habilidad == "suma vida")
                        {
                            if (heroe.vida+x>heroe.maxvida) { heroe.vida = heroe.maxvida; }
                            else { heroe.vida += x; }
                        }
                        else if (habilidad == "suma mana") { heroe.mana += x; }
                        else if (habilidad == "suma ataque") { heroe.ataque += x; }
                        else if (habilidad == "suma armadura") { heroe.armadura += x; }
                        else if (habilidad == "roba carta")
                        {
                            for (int i = 1; i <= x; i++)
                            {
                                heroe.Robar();
                            }
                        }
                        else { habilidad = null; }
                    }
                    if (objetivo is Esbirro esbirro)
                    {
                        if (habilidad == "daña")
                        {
                            esbirro.RecibirDaño(x);
                        }
                        else if (habilidad == "suma vida")
                        {
                            if (esbirro.vida + x > esbirro.maxvida) { esbirro.vida = esbirro.maxvida; }
                            else
                            {
                                esbirro.vida += x;
                                if (esbirro.vida <= 0) { esbirro.Morir();}
                            }
                            
                        }
                        else { habilidad = null; }
                    }
                }
            }
        }
        //Este metodo activa todas las habilidades de una carta o heroe que corresponda al when introducido:
        public virtual void ActivarHabilidades(string when)
        {
            if (habilidades != null)
            {
                for (int i = 0; i < habilidades.Count; i++)
                {
                    Habilidad(habilidades[i], canthabilidad[i], objetivo[i]);
                }
            }
        }
    }
}