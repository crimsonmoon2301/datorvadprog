using System;
using System.IO;

namespace Task
{
    internal class Program
    {
        static IEnumerable<string> Meklet(string root, string target_file)
        {
            var files = new List<string>();

            foreach (var file in Directory.EnumerateFiles(root).Where(m => m.Contains(target_file)))
            {
                files.Add(file);
            }
            foreach (var subdir in Directory.EnumerateDirectories(root))
            {
                try
                {
                    files.AddRange(Meklet(subdir, target_file));
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("Fails atrodas tur, kur nav atļaujas lasīt!");
                    Console.WriteLine($"Kļūdas kods: {ex}");
                }
            }
            return files;
        }
        static void Main(string[] args)
        {
            bool stop = false;

            while (!stop)
            {
                Console.WriteLine("===Task praktiskais uzdevums===");
                Console.WriteLine("Izvēlies darbību: ");
                Console.WriteLine("1. Meklēt testa failu izmantojot rekursiju");
                Console.WriteLine("2. Meklēt failu izmantojot Task (Paralēlā meklēšana)");
                Console.WriteLine("3. Meklēt failu izmantojot Task (Advanced paralēlā meklēšana)");
                Console.WriteLine("0. Beigt");
                Console.Write("\nTava izvēle: ");
                string? opcija = Console.ReadLine();
                if(!int.TryParse(opcija, out int der))
                {
                    Console.WriteLine("Tev ir jāievada cipars!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (der)
                    {
                        case 1:
                            string start = @"E:\Datorvadiba programmesana\Task\Task\test";
                            string test_file = @"ja";
                            var files = Meklet(start, test_file);
                            foreach (var item in files)
                            {
                                Console.WriteLine($"Faila pilnais ceļš, izmantojot rekursiju: {item}");
                            }
                            
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 0:
                            stop = true;
                            Console.WriteLine("Programma beidz darbību!");
                            break;
                        default:
                            Console.WriteLine("Tādas izvēles šeit nav!");
                            break;
                    }
                }
            }
        }
    }
}
