using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    class Program
    {
        //Creando metodos que nos serán útiles:
        public static List<T> DesordenarLista<T>(List<T> input)
        {
            List<T> arr = input;
            List<T> arrDes = new List<T>();

            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }

            return arrDes;
        }
        public static void MostrarTablero(Heroe heroe)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tablero:");
            Console.WriteLine();
            Console.WriteLine(heroe.enemigo.duracion + "" + heroe.enemigo.ataque + " " + heroe.enemigo.vida + ":" + heroe.enemigo.armadura);
            foreach (Esbirro esbirro in heroe.enemigo.campo) { Console.Write(esbirro.ataque + "" + esbirro.vida + " "); }
            Console.WriteLine();
            Console.WriteLine();
            foreach (Esbirro esbirro in heroe.campo) { Console.Write(esbirro.ataque + "" + esbirro.vida + " "); }
            Console.WriteLine();
            Console.WriteLine(heroe.duracion + "" + heroe.ataque + " " + heroe.vida + ":" + heroe.armadura + " " + heroe.mana + "/" + heroe.maxmana + "   [{0}]", heroe.mazo.Count);
            foreach (Carta carta in heroe.mano)
            {
                if (carta is Esbirro esbirro) { Console.Write("E" + carta.costo + ":" + esbirro.ataque + esbirro.vida + " "); }
                else if (carta is Hechizo hechizo) { Console.Write("H" + carta.costo + ":" + hechizo.nombre + " "); }
                else if (carta is Arma arma) { Console.Write("A" + carta.costo + ":" + arma.ataque); }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public static int PreguntarNumero(int x,bool cero)
        {
            while (true)
            {
                try
                {
                    Console.Write("-->");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if ((y >= 0 && y <= x && cero==true)||(cero==false && y>0 && y<=x)) { return y; }
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.Write("Por favor digite una opción válida:");
                }
            }
        }

        //El Juego:
        static void Main(string[] args)
        {
            Console.WriteLine("PROYECTO HEARTHSTONE");
            Console.WriteLine();
            Console.WriteLine("Bienvenidos a la taberna, jugadores.");
            Console.WriteLine("Antes de partir elijan sus héroes. Estos son los disponibles y sus respectivas habilidades: ");
            Console.WriteLine();
            Console.WriteLine("1.Hunter : Inflige 2 de daño al héroe enemigo.");
            Console.WriteLine("2.Warrior : Obtiene 2 de armadura.");
            Console.WriteLine("3.Paladin : Invoca un Recluta de la Mano de Plata 1/1");
            //Console.WriteLine("4.Pícaro: Equipa una Daga 1/2");

            List<int> coin = new List<int>(); //esto lo usaremos para elegir quien parte

            //Pidiendo datos e instanciando heroes para cada jugador:
            Heroe j1 = new Heroe(null, null, null, null, null, null, null, null, null);
            Heroe j2 = new Heroe(null, null, null, null, null, null, null, null, j1);
            j1.enemigo = j2;
            List<Heroe> j = new List<Heroe>();
            j.Add(j1);
            j.Add(j2);
            for (int i=0; i<=1; i++)
            {
                List<Carta> tempmazo = new List<Carta>();
                List<string> temphabilidad = new List<string>();
                List<string> tempraza = new List<string>();
                List<int> tempcanthabilidad = new List<int>();
                List<List<Objeto>> tempobjetivos = new List<List<Objeto>>();
                List<string> tempcuando = new List<string>();
                


                //Seleccion de Heroe:
                while (true)
                {
                    Console.WriteLine();
                    Console.Write("Jugador {0}, ingresa el número de tu héroe: ", i+1);
                    int x = PreguntarNumero(3, false);

                    if (x == 1)
                    {
                        j[i].nombre = "Hunter";
                        j[i].descripcion = "Inflige 2 de daño al heroe enemigo";
                        temphabilidad.Add("daña");
                        List<Objeto> tempobjetivo = new List<Objeto>();
                        tempobjetivo.Add(j[i].enemigo);
                        tempobjetivos.Add(tempobjetivo);
                        tempcanthabilidad.Add(2);
                        tempcuando.Add(null);
                        tempraza.Add(null);
                        break;
                    }
                    else if (x == 2)
                    {
                        j[i].nombre = "Warrior";
                        j[i].descripcion = "Obtiene 2 de armadura";
                        temphabilidad.Add("suma armadura");
                        List<Objeto> tempobjetivo = new List<Objeto>();
                        tempobjetivo.Add(j[i]);
                        tempobjetivos.Add(tempobjetivo);
                        tempcanthabilidad.Add(2);
                        tempcuando.Add(null);
                        tempraza.Add(null);
                        break;
                    }
                    else if (x == 3)
                    {
                        j[i].nombre = "Paladin";
                        j[i].descripcion = "Invoca un Recluta de la Mano de Plata 1/1";
                        temphabilidad.Add("invoca");
                        List<Objeto> tempobjetivo = new List<Objeto>();
                        Esbirro tempesbirro1 = new Esbirro("Recluta de la Mano de Plata", 0, j[i], null, 1, 1, false, false, false, false, false, null, null, null, null, null, null);
                        tempobjetivo.Add(j[i]);
                        tempobjetivo.Add(tempesbirro1);
                        tempobjetivos.Add(tempobjetivo);
                        tempcanthabilidad.Add(1);
                        tempcuando.Add(null);
                        tempraza.Add(null);
                        break;
                    }
                    else if (x==4)
                    {

                    }
                }

                j[i].mazo = tempmazo;
                j[i].objetivo = tempobjetivos;
                j[i].habilidades = temphabilidad;
                j[i].raza = tempraza;
                j[i].canthabilidad = tempcanthabilidad;
                j[i].cuando = tempcuando;

                //Seleccion de Cartas, instanciandolas y agredandolas a mazo (en este caso omitiremos la selección y agregaremos las pedidas para la entrega):

                Esbirro tempesbirro = null;
                //3 wisp:
                for (int ii = 0; ii <= 2; ii++) 
                {
                    tempesbirro = new Esbirro("Wisp",0,j[i],null,1,1,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                //3 murloc raider:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Murloc raider",1,j[i],"murloc",1,2,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                //3 Bloodfen Raptor:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Bloodfen Raptor",2,j[i],"bestia",2,3,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                //3 River Crocolist:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("River Crocolist",2,j[i],"bestia",3,2,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                //3 Magma Rager:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Magma Rager",3,j[i],"elemental",1,5,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                //3 ChillWind Yeti:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Chillwind Yeti",4,j[i],null,5,4,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                //3 Oasis Snapjaw:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Oasis Snapjaw",4,j[i],"bestia",7,2,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                //3 Boulderfist Ogre:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Boulderfist Ogre",6,j[i],null,7,6,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                //3 War Golem:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("War Golem",7, j[i],null,7,7,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                //3 Core Hound:
                for (int ii = 0; ii <= 2; ii++)
                {
                    tempesbirro = new Esbirro("Core Hound",7, j[i],"bestia",5,9,false,false,false,false,false,null,null,null,null,null,null);
                    j[i].mazo.Add(tempesbirro);
                }
                j[i].mazo=DesordenarLista(j[i].mazo);

                //Entregando cartas iniciales:
                for (int ii = 0; ii <= 2; ii++) { j[i].Robar(); }

                coin.Add(i);
            }

            //Eligiendo quien parte: 
            Random random = new Random();
            int pri = random.Next(0, 2);
            coin.Remove(pri);
            int seg = coin[0];
            Console.WriteLine();
            Console.WriteLine("Jugador {0}, tú empiezas. ", pri+1);

            //y dando ventajas respectivas:
            j[seg].Robar();
            Console.WriteLine("Por lo tanto, Jugador {0}, tú recibes la moneda y una carta más. ", seg + 1);
            Console.WriteLine();

            //Dando la posibilidad de cambiar cartas iniciales:
            foreach (Heroe ju in j)
            {
                Console.Write("Jugador {0}, estas son tus cartas iniciales. ",j.IndexOf(ju)+1);
                List<Carta> tseleccion = new List<Carta>();
                int x = -1;
                int ca = 0;
                while (true)
                {
                    int tt = 1;
                    Console.WriteLine("Cual deseas cambiar:");
                    foreach (Carta carta in ju.mano)
                    {
                        Console.Write("{0}. ", tt);
                        Console.Write(carta.nombre);
                        Console.Write("({0}): ", carta.costo);
                        if (carta is Esbirro esbirro)
                        {
                            Console.Write("ataque {0}, ", esbirro.ataque);
                            Console.Write("vida {0}", esbirro.vida);
                        }
                        else if (carta is Arma arma)
                        {
                            Console.Write("ataque {0}, ", arma.ataque);
                            Console.Write("duración {0}", arma.duracion);
                        }
                        if (carta.descripcion != null) { Console.Write(" ({0})", carta.descripcion); }
                        Console.WriteLine();
                        tt += 1;
                    }
                    Console.WriteLine("0. Listo");
                    Console.WriteLine();
                    x = PreguntarNumero(ju.mano.Count, true);
                    if (x == 0) { break; }
                    ju.mazo.Add(ju.mano[x - 1]);
                    ju.mano.Remove(ju.mano[x - 1]);
                    ca += 1;
                }
                while (ca!=0)
                {
                    ju.Robar();
                    ca -= 1;
                }
                ju.mazo=DesordenarLista(ju.mazo);
            }

            //instanciando y dando moneda:
            List<string> temphabilidad1 = new List<string>();
            List<string> tempraza1 = new List<string>();
            List<int> tempcanthabilidad1 = new List<int>();
            List<List<Objeto>> tempobjetivos1 = new List<List<Objeto>>();
            List<string> tempcuando1 = new List<string>();
            List<Objeto> tempobjetivo1 = new List<Objeto>();
            temphabilidad1.Add("suma mana");
            tempraza1.Add(null);
            tempcanthabilidad1.Add(1);
            tempcuando1.Add(null);
            tempobjetivo1.Add(j[seg]);
            tempobjetivos1.Add(tempobjetivo1);

            Hechizo moneda = new Hechizo("Moneda", 0, j[seg], "Ganas 1 de mana por este turno",temphabilidad1,tempobjetivos1,tempraza1,tempcanthabilidad1,tempcuando1);
            j[seg].mano.Add(moneda);

            //Empezando la partida:
            Console.WriteLine();
            Console.WriteLine("COMIENZA LA PARTIDA");
            int ij = pri;
            while (true) //los ciclos son cada turno. Ej: ciclo1: jugador1, ciclo2: j2, ciclo3: j1... hasta que alguno tenga vida menor a 1.
            {
                j[ij].Iniciarturno();

                //Interacción del usuario:
                int x = -1;
                while (x!=0)
                {
                    MostrarTablero(j[ij]);
                    //Preguntando al usuario que desea hacer en su turno:
                    Console.WriteLine();
                    Console.WriteLine("Jugador {0}, que quieres hacer: ", ij+1);
                    Console.WriteLine("1. Activar una carta");
                    Console.WriteLine("2. Atacar con tu héroe");
                    Console.WriteLine("3. Atacar con un esbirro");
                    Console.WriteLine("4. Usar tu habilidad(2): {0}", j[ij].descripcion);
                    Console.WriteLine("0. Terminar tu turno");
                    x = PreguntarNumero(4, true);

                    //Activar una carta:
                    while (x==1)
                    {
                        //Preguntando al usuario qué carta quiere activar de las posibles:
                        Console.WriteLine();
                        Console.WriteLine("Tu mana: {0}", j[ij].mana);
                        Console.WriteLine("Que carta quieres activar: ");
                        List<Carta> tmano = new List<Carta>();
                        int ii = 1;
                        for (int i=0;i<j[ij].mano.Count;i++)
                        {
                            if (j[ij].mana>=j[ij].mano[i].costo)
                            {
                                Console.Write("{0}. ", ii);
                                Console.Write(j[ij].mano[i].nombre);
                                Console.Write("({0}): ", j[ij].mano[i].costo);
                                if (j[ij].mano[i] is Esbirro esbirro)
                                {
                                    Console.Write("ataque {0}, ", esbirro.ataque);
                                    Console.Write("vida {0}", esbirro.vida);
                                }
                                else if (j[ij].mano[i] is Arma arma)
                                {
                                    Console.Write("ataque {0}, ", arma.ataque);
                                    Console.Write("duración {0}", arma.duracion);
                                }
                                if (j[ij].mano[i].descripcion != null) { Console.Write(" ({0})", j[ij].mano[i].descripcion); }
                                Console.WriteLine();
                                tmano.Add(j[ij].mano[i]);
                                ii++;
                            }
                        }
                        Console.WriteLine("0. Cancelar");
                        int y = PreguntarNumero(tmano.Count, true);
                        if (y==0) { break; }
                        //Activando carta seleccionada:
                        tmano[y - 1].ActivarCarta();
                    }
                    //Atacando con heroe (no terminado ya que no se necesita para esta entrega)
                    if (x==2)
                    {
                        if (j[ij].puedeatacar<1||j[ij].duracion==0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("No puedes atacar.");
                        }
                        else
                        {

                        }
                        
                    }
                    //Atacando con esbirro:
                    while (x==3)
                    {
                        //Preguntando al usuario con que carta quiere atacar de las disponibles:
                        Console.WriteLine();
                        Console.WriteLine("Con cuál esbirro quieres atacar: ");
                        List<Esbirro> tcampo = new List<Esbirro>();
                        int i = 1;
                        foreach (Esbirro esbirro in j[ij].campo)
                        {
                            if (esbirro.atacar==1&&esbirro.ataque>0)
                            {
                                Console.Write("{0}. ", i);
                                Console.Write(esbirro.nombre);
                                Console.Write(": ataque {0}, vida ", esbirro.ataque);
                                Console.WriteLine(esbirro.vida);
                                i += 1;
                                tcampo.Add(esbirro);
                            }
                        }
                        Console.WriteLine("0. Cancelar");
                        int y = PreguntarNumero(tcampo.Count,true);
                        if (y==0) { break; }
                        else
                        {
                            //Preguntando al usuario a quién desea atacar:
                            Console.WriteLine();
                            Console.WriteLine("A quién quieres atacar: ");
                            //Revisando si alguno tiene provocación:
                            bool tprov = false;
                            foreach (Esbirro esbirro in j[ij].enemigo.campo) { if (esbirro.provocacion) { tprov = true; } }
                            //Mostrando disponibles según provocación:
                            List<Objeto> tobjetivo = new List<Objeto>();
                            i = 1;
                            if (!tprov)
                            {
                                Console.WriteLine("1. Héroe enemigo");
                                tobjetivo.Add(j[ij].enemigo);
                                i += 1;
                            }
                            foreach (Esbirro esbirro in j[ij].enemigo.campo)
                            {
                                if (tprov && !esbirro.provocacion) { continue; }
                                else
                                {
                                    Console.Write("{0}. ", i);
                                    Console.Write(esbirro.nombre);
                                    Console.Write(": ataque {0}, vida ", esbirro.ataque);
                                    Console.WriteLine(esbirro.vida);
                                    i += 1;
                                    tobjetivo.Add(esbirro);
                                }
                            }
                            Console.WriteLine("0. Cancelar");
                            Console.Write("-->");
                            int z = PreguntarNumero(tobjetivo.Count, true);
                            if (z == 0) { break; }
                            tcampo[y - 1].Atacar(tobjetivo[z - 1]);
                            break;
                        }
                    }
                    //Usando habilidad de héroe:
                    if (x==4)
                    {
                        if (j[ij].mana < 2 || j[ij].puedehabilidad == false)
                        {
                            Console.WriteLine();
                            Console.WriteLine("No puedes usar tu habilidad.");
                            Console.ReadLine();
                        }
                        else { j[ij].UsarHabilidad(); }
                    }
                    //Verificando si alguien ya ganó:
                    if (j[1].vida <= 0 || j[0].vida <= 0) { break; }
                }
                //Verificando si alguien ya ganó:
                if(j[1].vida <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("¡Jugador 1 ha ganado!");
                    break;
                }
                if(j[0].vida <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("¡Jugador 2 ha ganado!");
                    break;
                }
                //Terminando turno
                j[ij].Terminarturno();
                ij += 1;
                if (ij == 2) { ij = 0; }
            }
            Console.WriteLine();
            Console.WriteLine("FIN DEL JUEGO");
            Console.Read();
        }
    }
}
