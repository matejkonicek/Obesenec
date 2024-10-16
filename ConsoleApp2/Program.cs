using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main()
        {
            string[] slova = { "most", "vlak", "hrnek", "rak", "had", "boty", "strop", "voda", "lis",
                               "hrad", "lesk", "bunda", "klub", "kniha", "bratr", "matka", "vlna",
                               "metro", "park", "krab", "sklo", "plot",
                               "prut", "rada", "zrak", "kost", "smrk", "pes", "metr", "hrnek", "led", "loket", "strom"};
            Random random = new Random();
            string slovo = slova[random.Next(slova.Length)];

            char[] skryteSlovo = new string('_', slovo.Length).ToCharArray();
            List<char> uhodnutaPismena = new List<char>();
            List<char> spatnaPismena = new List<char>();
            int maxPokusy = 6;

            while (spatnaPismena.Count < maxPokusy && new string(skryteSlovo) != slovo)
            {
                Console.Clear();
                ZobrazObesence(spatnaPismena.Count);
                Console.WriteLine("Uhodnuté slovo: " + new string(skryteSlovo));
                Console.WriteLine("Špatná písmena: " + string.Join(", ", spatnaPismena));

                Console.Write("Zadej písmeno: ");
                char pismeno = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (slovo.Contains(pismeno))
                {
                    uhodnutaPismena.Add(pismeno);
                    for (int i = 0; i < slovo.Length; i++)
                    {
                        if (slovo[i] == pismeno)
                        {
                            skryteSlovo[i] = pismeno;
                        }
                    }
                }
                else
                {
                    spatnaPismena.Add(pismeno);
                }
            }

            Console.Clear();
            ZobrazObesence(spatnaPismena.Count);
            if (new string(skryteSlovo) == slovo)
            {
                Console.WriteLine("Gratulace! Uhodl jsi slovo: " + slovo);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Prohrál jsi! Slovo bylo: " + slovo);
                Console.ReadLine();
            }
        }

        static void ZobrazObesence(int pokusy)
        {
            Console.WriteLine(" +---+");
            Console.WriteLine(" |   |");
            switch (pokusy)
            {
                case 0:
                    Console.WriteLine("     |");
                    Console.WriteLine("     |");
                    Console.WriteLine("     |");
                    break;

                case 1:
                    Console.WriteLine(" O   |");
                    Console.WriteLine("     |");
                    Console.WriteLine("     |");

                    break;

                case 2:
                    Console.WriteLine(" O   |");
                    Console.WriteLine(" |   |");
                    Console.WriteLine("     |");
                    break;

                case 3:
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|   |");
                    Console.WriteLine("     |");
                    break;

                case 4:
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|\\  |");
                    Console.WriteLine("     |");
                    break;

                case 5:
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|\\  |");
                    Console.WriteLine("/    |");
                    break;

                case 6:
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|\\  |");
                    Console.WriteLine("/ \\  |");
                    break;
            }

            Console.WriteLine("     |");
            Console.WriteLine("=========");
        }
    }
}
