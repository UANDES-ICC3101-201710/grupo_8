using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneProject
{
    public class Heroe : Objeto, IVivos
    {
        public string nombre;
        public string heroe;
        public Heroe enemigo;
        public int vida;
        public int maxvida;
        public int armadura;
        public int ataque;
        public int duracion;
        public int mana;
        public int maxmana;
        public int puedeatacar;
        public bool puedehabilidad;
        public List<Carta> mazo;
        public List<Carta> mano;
        public List<Esbirro> campo;
        public List<Carta> cementerio;
        public string ihabilidad;

        public Heroe(string nombre, string heroe, string descripcion, List<Carta> mazo, List<string> habilidades, List<List<Objeto>> objetivo, List<int> canthabilidad, Heroe enemigo,string imagen, string ihabilidad)
        {
            this.descripcion = descripcion;
            this.enemigo = enemigo;
            this.habilidades = habilidades;
            this.objetivo = objetivo;
            this.canthabilidad = canthabilidad;
            maxvida = 30;
            vida = 30;
            armadura = 0;
            ataque = 0;
            mana = 0;
            maxmana = 0;
            puedeatacar = 0;
            puedehabilidad = false;
            List<Carta> cem = new List<Carta>();
            cementerio = cem;
            List<Carta> man = new List<Carta>();
            mano = man;
            List<Esbirro> cam = new List<Esbirro>();
            campo = cam;
            this.nombre = nombre;
            this.mazo = mazo;
            this.imagen = imagen;
            this.ihabilidad = ihabilidad;
            this.heroe = heroe;
        }
        public void Iniciarturno()
        {
            if (maxmana < 10) { maxmana += 1; }
            mana = maxmana;
            Robar();
            puedeatacar += 1;
            puedehabilidad = true;

        }
        public void Robar()
        {
            if (mazo.Count == 0) { RecibirDaño(1); }
            else if (mano.Count == 10)
            {
                mazo.RemoveAt(0);
            }
            else
            {
                mano.Add(mazo[0]);
                mazo.Remove(mazo[0]);
            }
            
        }

        //Metodos propios de los vivos (IVivos):
        public void RecibirDaño(int daño)
        {
            if (daño <= armadura) { armadura -= daño; }
            else
            {
                vida -= daño - armadura;
                armadura = 0;
            }
        }
        public void Atacar(Objeto objetivo)
        {
            if (objetivo is Heroe heroe)
            {
                heroe.RecibirDaño(ataque);
            }
            else if (objetivo is Esbirro esbirro)
            {
                esbirro.RecibirDaño(ataque);
            }
            puedeatacar = 0;
        }

        //Activa la habilidad de heroe descrita:
        public void UsarHabilidad()
        {
            ActivarHabilidades(null);
            mana -= 2;
            puedehabilidad = false;
        }
        public void Terminarturno()
        {
            foreach (Esbirro esbirro in campo)
            {
                esbirro.atacar += 1;
            }
        }
    }
}