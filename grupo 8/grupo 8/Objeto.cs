using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneProject
{
    public abstract class Objeto : IObjeto
    {
        //Todas nuestras clases tienen la posibilidad de tener habilidades, esta es la razón de la creación de esta clase.

        public List<string> habilidades;
        public List<List<Objeto>> objetivo; //los objetivos pueden ser Esbirro o Héroe.
        public List<string> raza;           //la raza de los objetivos afectados (Ej: "Suma 1 de atque a tus BESTIAS")
        public List<int> canthabilidad;     //Cuanto afectará al objetivo
        public List<string> cuando;         //Indica cuándo se activará la habilidad. Ej: "Grito de batalla:..., Estertor:..., etc).
        public string descripcion;          //Un resumen de que hacen todas las habilidades.

        //Este método activa un efecto de habilidad:
        public virtual void Habilidad(string habilidad, int x, List<Objeto> objetivos, string tipo)
        {
            if (habilidad == "invoca")
            {
                for (int i = 0; i < x; i++)
                {
                    Esbirro invocado = (Esbirro)objetivos[1];
                    (objetivos[0] as Heroe).campo.Add(new Esbirro(invocado.nombre,invocado.costo,invocado.dueño,invocado.tipo,invocado.vida,invocado.ataque,invocado.provocacion,invocado.veneno,invocado.viento,invocado.escudo,invocado.sigilo,invocado.habilidades,invocado.objetivo,invocado.raza,invocado.canthabilidad,invocado.cuando,invocado.descripcion));
                }
            }
            else if (habilidad != null)
            {
                foreach (Objeto objetivo in objetivos)
                {
                    if (objetivo is Heroe heroe)
                    {
                        if (habilidad == "daña")
                        {
                            heroe.RecibirDaño(x);
                        }
                        else if (habilidad == "cambia vida") { heroe.vida = x; }
                        else if (habilidad == "suma vida") { heroe.vida += x; }
                        else if (habilidad == "suma mana") { heroe.mana += x; }
                        else if (habilidad == "suma maxmana") { heroe.maxmana += x; }
                        else if (habilidad == "cambia ataque") { heroe.ataque = x; }
                        else if (habilidad == "suma ataque") { heroe.ataque += x; }
                        else if (habilidad == "cambia armadura") { heroe.armadura = x; }
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
                    if (objetivo is Esbirro esbirro && esbirro.tipo == tipo && !esbirro.inmune)
                    {
                        if (habilidad == "daña")
                        {
                            esbirro.RecibirDaño(x);
                        }
                        else if (habilidad == "cambia vida")
                        {
                            esbirro.vida = x;
                            if (esbirro.vida <= 0) { esbirro.Morir(); }
                        }
                        else if (habilidad == "suma vida")
                        {
                            esbirro.vida += x;
                            if (esbirro.vida <= 0) { esbirro.Morir(); }
                        }
                        else if (habilidad == "cambia ataque") { esbirro.ataque = x; }
                        else if (habilidad == "suma ataque") { esbirro.ataque += x; }
                        else if (habilidad == "suma maxvida")
                        {
                            esbirro.maxvida += x;
                            esbirro.vida += x;
                            if (esbirro.vida <= 0) { esbirro.Morir(); }
                        }
                        else if (habilidad == "otorga veneno") { esbirro.veneno = true; }
                        else if (habilidad == "otorga provocacion") { esbirro.provocacion = true; }
                        else if (habilidad == "otorga viento") { esbirro.viento = true; }
                        else if (habilidad == "otorga escudo") { esbirro.escudo = true; }
                        else if (habilidad == "otorga sigilo") { esbirro.sigilo = true; }
                        else if (habilidad == "otorga inmunidad") { esbirro.inmune = true; }
                        else if (habilidad == "silencia")
                        {
                            esbirro.provocacion = false;
                            esbirro.escudo = false;
                            esbirro.sigilo = false;
                            esbirro.veneno = false;
                            esbirro.viento = false;
                            for (int i = 0; i < esbirro.habilidades.Count; i++)
                            {
                                esbirro.habilidades[i] = null;
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
                    if (cuando[i] == when) { Habilidad(habilidades[i], canthabilidad[i], objetivo[i], raza[i]); }
                }
            }
        }
    }
}