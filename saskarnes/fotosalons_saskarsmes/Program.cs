using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fotosalons_saskarsmes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("1. Sākt izmantot Array.Sort(), sakārtot augošā secībā pēc NĪN maksājumiem");
                Console.WriteLine("2. Apskatīt sarakstu");
                Console.WriteLine("0. Iziet\n");
                Console.Write("Tava izvēle: ");
                string izvele = Console.ReadLine();

                if (int.TryParse(izvele, out int valid))
                {
                    switch (valid)
                    {
                        case 1:
                           
                            break;
                        case 2:
                           
                            break;
                        case 0:
                            stop = true;
                            Console.WriteLine("Programma apturēta!");
                            break;
                        default:
                            Console.WriteLine("Tādas opcijas nav!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}
