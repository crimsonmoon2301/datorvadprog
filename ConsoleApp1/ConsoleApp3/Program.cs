using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace ConsoleApp3
{
    internal class Program
    {
        public static bool stop = false;
        delegate string TextProcessing(string input);

        public static string NormalizeText(string input)
        {
            return input.ToLower();
        }
        public static string RemoveExtraSymbols(string input)
        {
            return Regex.Replace(input, "[^\\w\\._]", "");
        }
        public static string CountWords(string input)
        {
            return "Vārdu skaits: " + input.Length.ToString();
        }

        

        static void Main(string[] args)
        {
            TextProcessing del = null;
            Console.Write("Ievadi tekstu: ");
            string teksts = Console.ReadLine();
            List<TextProcessing> pipeline = new List<TextProcessing>();

            while (!stop)
            {
                Console.WriteLine("Izvēlies darbību: ");
                Console.WriteLine("1 - Pievienot posmu NormalizeText");
                Console.WriteLine("2 - Pievienot posmu RemoveExtraSymbols");
                Console.WriteLine("3 - Pievienot posmu CountWords");
                Console.WriteLine("0 - Palaist konveijeru");
                Console.WriteLine("9 - Iziet");

                Console.WriteLine("Pašreizējā ķēde: ");

                for (int i = 0; i < pipeline.Count; i++)
                {
                    Console.WriteLine($"<{pipeline[i].Method.Name}>");
                }
                Console.Write("Izvēlētā opcija: ");
                string opcija = Console.ReadLine();
                switch (opcija)
                {
                    case "1":
                        AddStage(pipeline, NormalizeText);
                        Console.WriteLine("Posms NormalizeText pievienots");
                        break;
                    case "2":
                        AddStage(pipeline, RemoveExtraSymbols);
                        Console.WriteLine("Posms RemoveExtraSymbols pievienots");
                        break;
                    case "3":
                        AddStage(pipeline, CountWords);
                        Console.WriteLine("Posms CountWords pievienots");
                        break;
                    case "0":
                        string rez = teksts;
                        foreach (TextProcessing konv in pipeline)
                        {
                            rez = konv(rez);
                        }
                        Console.WriteLine($"Rezultāts: {rez}");
                        break;
                    case "9":
                        Console.WriteLine("Programma beidz darbību!");
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Tādas opcijas nav!");
                        break;
                }
            }
        }
        static void AddStage(List<TextProcessing> pipeline, TextProcessing stage)
        {
            pipeline.Add(stage);
        }

    }

}
