using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        // Anonīmās funkcijas ir funkcijas, kuriem nav piešķirti nosaukumi. Tos mēdz izpildīt izmantojot lambda izteiksmes (skatīt zemāk)
        // Predikāti ir delegātu veids, kas atgriež true vai false. Tos parasti papildina ar anonīmām (lambda) funkcijām, padarot viņus par labām metodēm priekš filtrācijas operācijām.
        // 
        static Predicate<int> parask = num => num % 2 == 0;
        static Predicate<int> dalaar3 = num => num % 3 == 0;
        static Predicate<int> lielakspar100 = num => num > 100;
        static Predicate<int> satur0 = num => num.ToString().Contains("0");
        static Predicate<int> dalaar10 = num => num % 10 == 0;

        public static bool stop = false;
        static void Main(string[] args)
        {
            List<int> saraksts = new List<int>();
            List<int> filtrets = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < 20; i++)
            {
                saraksts.Add(rand.Next(1, 200));
            }

            while (!stop)
            {
                
                if (filtrets.Count != 0)
                {
                    Console.WriteLine("Filtrēts rezultāts:");
                    foreach (var item in filtrets)
                    {
                        Console.Write(item + " ");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                

                Console.WriteLine("Oriģinālais saraksts: ");
                for (int i = 0; i < saraksts.Count; i++)
                {
                    Console.Write(saraksts[i] + " ");
                }
                Console.WriteLine("\nIzvēlies filtrus:");
                Console.WriteLine("1 - Pāra skaitlis");
                Console.WriteLine("2 - dalās ar 3 bez atlikuma");
                Console.WriteLine("3 - lielāki par 100");
                Console.WriteLine("4 - satur ciparu 0");
                Console.WriteLine("5 - dalās ar 10 bez atlikuma");
                Console.Write("Tava opcijas: ");
                //string izvele = Console.ReadLine();
                //string[] opcija = izvele.Split();
                
                string izvelne = Console.ReadLine();

                

                string[] opcija = izvelne.Split();
                
                

                
                foreach (string izvelnes in opcija)
                {
                    filtrets = saraksts;

                    switch (izvelnes)
                    {
                        case "1":
                            filtrets = filtrets.FindAll(parask);

                            //Console.WriteLine("Filtrēts rezultāts:");
                            //foreach (var item in filtrets)
                            //{
                            //    Console.Write(item + " ");
                            //}
                            //Console.ReadKey();
                            break;
                        case "2":
                            filtrets = filtrets.FindAll(dalaar3);

                            //Console.WriteLine("Filtrēts rezultāts:");
                            //foreach (var item in filtrets)
                            //{
                            //    Console.Write(item + " ");
                            //}
                            //Console.ReadKey();
                            break;
                        case "3":
                            filtrets = filtrets.FindAll(lielakspar100);

                            //Console.WriteLine("Filtrēts rezultāts:");
                            //foreach (var item in filtrets)
                            //{
                            //    Console.Write(item + " ");
                            //}
                            //Console.ReadKey();
                            break;
                        case "4":
                            filtrets = filtrets.FindAll(satur0);

                            //Console.WriteLine("Filtrēts rezultāts:");
                            //foreach (var item in filtrets)
                            //{
                            //    Console.Write(item + " ");
                            //}
                            //Console.ReadKey();
                            break;
                        case "5":
                            filtrets = filtrets.FindAll(dalaar10);

                            //Console.WriteLine("Filtrēts rezultāts:");
                            //foreach (var item in filtrets)
                            //{
                            //    Console.Write(item + " ");
                            //}
                            //Console.ReadKey();
                            break;
                        
                        default:
                            Console.WriteLine("Nepareiza opcija!");
                            Console.Clear();
                            break;
                    }
                    
                }
                
            }
        }
    }
}
  