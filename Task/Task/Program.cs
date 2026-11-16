using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Task_uzdevums
{
    internal class Program
    {
        static IEnumerable<string> Meklet(string root, string target_file)
        {
            var files = new List<string>();

            foreach (var file in Directory.EnumerateFiles(root))
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
        static ConcurrentBag<string> MekletarTask(string root, string target_file)
        {
            var files = new ConcurrentBag<string>();

            foreach (var file in Directory.EnumerateFiles(root).Where(m => m.Contains(target_file)))
            {
                files.Add(file);
            }
            var tasks = new List<Task>();

            foreach (var subdir in Directory.EnumerateDirectories(root))
            {
                tasks.Add(Task.Run(() =>
                {
                    var subFiles = MekletarTask(subdir, target_file);
                    foreach (var subfile in subFiles)
                    {
                        files.Add(subfile);
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            return files;
        }
        
        // Šo gan vajadzēja vibe-codot. Manu pašu piegājiens kautkā salauza rekursiju. Neprasi kāpēc
        static ConcurrentBag<string> MekletarTaskAdv(string root, string target_file, string text)
        {
            var files = new ConcurrentBag<string>();

            if (string.IsNullOrWhiteSpace(target_file) || target_file.Length < 3)
            {
                Console.WriteLine("Faila nosaukuma sākuma daļai jābūt vismaz 3 simbolus garai!");
                return files;
            }
            var tasks = new List<Task>();

            try
            {
                foreach (var file in Directory.EnumerateFiles(root))
                {
                    string fileName = Path.GetFileName(file);

                    if (fileName.StartsWith(target_file, StringComparison.OrdinalIgnoreCase))
                    {
                        string currentFile = file;
                        tasks.Add(Task.Run(() =>
                        {
                            try
                            {
                                string saturs = File.ReadAllText(currentFile);
                                if (saturs.Contains(text, StringComparison.OrdinalIgnoreCase))
                                {
                                    files.Add(currentFile);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Kautkas aizgāja greizi");
                                Console.WriteLine($"Kļūdas kods: {ex}");
                            }
                        }));
                    }
                }

                foreach (var subdir in Directory.EnumerateDirectories(root))
                {
                    string currentSubdir = subdir;

                    tasks.Add(Task.Run(() =>
                    {
                        try
                        {
                            var subFiles = MekletarTaskAdv(currentSubdir, target_file, text);
                            foreach (var subfile in subFiles)
                            {
                                files.Add(subfile);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Kļūda apakšmapē]: {ex.Message}");
                        }
                    }));
                }
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Kļūda apstrādājot mapi '{root}']: {ex.Message}");
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
                            string start1 = @"E:\Datorvadiba programmesana\Task\Task\test";
                            string test_file1 = @"otraistestsartask";
                            var files1 = Meklet(start1, test_file1);
                            foreach (var item in files1)
                            {
                                Console.WriteLine($"Faila pilnais ceļš, izmantojot Task: {item}");
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Ievadi pirmos trīs simbolus failam ko vēlies meklēt: ");
                            string startpos = @"E:\Datorvadiba programmesana\Task\Task\test";

                            string? prefix = Console.ReadLine();
                            Console.Write("\nKādam tekstam jābūt failā? (Atslēgasvārdi, utt.): ");
                            string? keywords = Console.ReadLine();
                            

                            var files3 = MekletarTaskAdv(startpos, prefix, keywords);
                                
                            foreach (var item in files3)
                            {
                                Console.WriteLine($"Faila pilnais ceļš, izmantojot Task un tekstu: {item}");
                            }
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
