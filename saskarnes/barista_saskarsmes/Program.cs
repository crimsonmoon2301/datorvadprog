using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barista_saskarsmes
{
    internal class Program
    {
        public interface IKafija
        {
            void Pagatavot();
        }

        public class Espresso: IKafija
        {
            public void Pagatavot()
            {
                Console.WriteLine("Tiek pagatavots espresso no augsta spiediena preses un no samaltām kafijas pupiņām...");
                Console.WriteLine("Espresso tiek sagatavots mazā espresso krūzītē...");
                Console.WriteLine("Kafija pasniegta klientam. Labi padarīts!");
            }
            
        }
        public class FlatWhite: IKafija
        { 
            public void Pagatavot()
            {
                Console.WriteLine("Tiek pagatavots espresso no augsta spiediena preses un no samaltām kafijas pupiņām...");
                Console.WriteLine("Tiek samtaini putots piens...");
                Console.WriteLine("Flat White tiek sagatavots kafijas krūzē...");
                Console.WriteLine("Kafija pasniegta klientam. Labi padarīts!");
            }
        }
        public class Latte: IKafija
        { 
            public void Pagatavot()
            {
                Console.WriteLine("Tiek pagatavots espresso no augsta spiediena preses un no samaltām kafijas pupiņām...");
                Console.WriteLine("Tiek tvaicēts piens un arī samtaini putots..");
                Console.WriteLine("Latte tiek pasniegta lielā kafijas glāzē...");
                Console.WriteLine("Kafija pasniegta klientam. Labi padarīts!");
            }
        }
        public class Lungo: IKafija
        {
            public void Pagatavot()
            {
                Console.WriteLine("Tiek pagatavoti divi espresso šoti no augsta spiediena preses un no samaltām kafijas pupiņām...");
                Console.WriteLine("Lungo pasniegšanā tiek liets 2 reizes vairāk ūdens nekā espresso...");
                Console.WriteLine("Lungo tiek pasniegta vidējā kafijas krūzē...");
                Console.WriteLine("Kafija pasniegta klientam. Labi padarīts!");
            }
        }
        static void Main(string[] args)
        {
            bool stop = false;
            
            while (!stop)
            {
                
                IKafija[] veikals = new IKafija[]
                {
                    new Espresso(),
                    new FlatWhite(),
                    new Latte(),
                    new Lungo()
                };
                Console.WriteLine("=== Kafejnīcas baristas sistēma ===");
                Console.WriteLine("1. Pagatavot Dubulto espresso");
                Console.WriteLine("2. Pagatavot Flat White");
                Console.WriteLine("3. Pagatavot Latti ");
                Console.WriteLine("4. Pagatavot Lungo (Espresso, bet 2x ūdens)");

                Console.WriteLine("0. Beigt darbu\n");
                Console.Write("Tava izvēle: ");
                string izvele = Console.ReadLine();

                
                if (int.TryParse(izvele, out int valid))
                {
                    switch (valid)
                    {
                        case 1:
                            Console.WriteLine("Klients pasūtīja dubulto espresso. Tu sāc gatavot espresso aparātu..");
                            Console.WriteLine("Spied jebkuru pogu, lai sāktu!");
                            Console.ReadKey();
                            veikals[0].Pagatavot();
                            break;
                        case 2:
                            Console.WriteLine("Klients pasūtīja Flat White. Tu sāc gatavot espresso aparātu..");
                            Console.WriteLine("Spied jebkuru pogu, lai sāktu!");
                            Console.ReadKey();
                            veikals[1].Pagatavot();
                            break;
                        case 3:
                            Console.WriteLine("Klients pasūtīja Latti. Tu sāc gatavot espresso aparātu, kā arī pienu..");
                            Console.WriteLine("Spied jebkuru pogu, lai sāktu!");
                            Console.ReadKey();
                            veikals[2].Pagatavot();
                            break;
                        case 4:
                            Console.WriteLine("Klients pasūtīja Lungo. Tu sāc gatavot espresso aparātu..");
                            Console.WriteLine("Spied jebkuru pogu, lai sāktu!");
                            Console.ReadKey();
                            veikals[3].Pagatavot();
                            break;
                        case 0:
                            stop = true;
                            Console.WriteLine("Darba maiņa beigta. Labi padarīts!");
                            break;
                        default:
                            Console.WriteLine("Tādas opcijas nav!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Tev ir jāievada cipars!");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}