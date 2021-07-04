using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinero_engañoso
{

    public class Program
    {
        static void Instrucciones()
        {
            Console.WriteLine("Bienvenido a 'Dinero Engañoso'!");
            Console.WriteLine("");
            Console.WriteLine("INSTRUCCIONES Y COMO JUGAR:");
            Console.WriteLine("");
            Console.WriteLine("La mecánica es simple. Existirá un porcentaje que ira disminuyendo a medida que avanzas en el juego.");
            Console.WriteLine("Cuanto mas avanzas, mas dinero ganas por ronda, pero por cada una de ellas el porcentaje de éxito se reduce un 1%.");
            Console.WriteLine("En caso de que en una ronda sigas, y pierdas, perderás todo el dinero, por eso has de pensar cuando reservar o no.");
            Console.ReadKey();
        }
        public static void Main()
        {
            Rondas.ronda = 0;
            Rondas.prob = 101;
            Rondas.dinerofin = 5;
            Rondas.dineroprevio = 0;
            Rondas.dinerototalprev = 0;
            Rondas.dinerototalfin = 0;
            Console.Clear();
            Instrucciones();
            Rondas.Ronda();
        }
    }

    public class Rondas
    {
        static public int ronda;
        static public int prob = 101;
        static public int dinerofin = 5;
        static public int dineroprevio;
        static public int dinerototalprev;
        static public int dinerototalfin;

        public static void Ronda()
        {
            ronda++;
            prob -= 1;
                int temp = dinerofin;
                dinerofin += dineroprevio;
                dineroprevio = temp;
                int temp2 = dinerofin;
                dinerototalfin += dinerototalprev;
                dinerototalprev = temp2;
            Console.WriteLine("RONDA {0}", ronda);
            Console.WriteLine("Tu probabilidad es del {0}%", prob);
            Console.WriteLine("");
            Console.WriteLine("Recibes {0} euros, prosigues? (Y/N)", dinerofin);
            if (prob <= 90)
            {
                Dialogos();
            }
            string input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                case "y":
                    Probabilidad();
                    break;
                case "N":
                case "n":
                    Console.WriteLine("Te retiras con un total de {0} euros. Bien hecho!", dinerototalfin);
                    Console.ReadKey();
                    Program.Main();
                    break;
                default:
                    Probabilidad();
                    break;
            }
        }
        static void Probabilidad()
        {
            Random probs = new Random();
            int resultado = probs.Next(1, 99);
            if (resultado > Rondas.prob)
            {
                Console.WriteLine("Alto ahí! La probabilidad fue en tu contra, has perdido tus {0} euros, camarada.", dinerototalfin);
                Console.ReadKey();
                Program.Main();
            }
            else
            {
                Console.WriteLine("Perfecto! Has ganado {0} euros.", dinerofin);
                Rondas.Ronda();
            }
        }
        static void Dialogos()
        {
            string[] dialogos = { "No sigas, es peligroso!", "Vas a perder todo el dinero rey.", "Porque te gusta sufrir? Asegura...", "Estás loco, en serio." };
            Random rnd = new Random();
            int select = rnd.Next(1,4);
            switch (select)
            {
                case 1:
                    Console.WriteLine(dialogos[0]);
                    break;
                case 2:
                    Console.WriteLine(dialogos[1]);
                    break;
                case 3:
                    Console.WriteLine(dialogos[2]);
                    break;
                case 4:
                    Console.WriteLine(dialogos[3]);
                    break;
            }
        }
    }
}
