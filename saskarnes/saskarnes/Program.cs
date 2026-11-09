using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saskarnes
{
    internal class Program
    {
        public class Māja : IComparable
        {
            public string pilseta;
            public string ielas_nos;
            public string ielas_nr;
            public string adrese;
            public double platums;
            public double garums;
            public double zemes_plat;

            public Māja(string pilseta, string ielas_nos, string ielas_nr, double platums, double garums, double zemes_plat)
            {
                this.pilseta = pilseta;
                this.ielas_nos = ielas_nos;
                this.ielas_nr = ielas_nr;
                this.adrese = $"{pilseta}, {ielas_nos} {ielas_nr}";
                this.platums = platums;
                this.garums = garums;
                this.zemes_plat = zemes_plat;
            }

            public double NIN_aprekins()
            {
                double nodoklis = ((platums * garums) * 100) + (zemes_plat - (platums * garums) * 10);
                return nodoklis;
            }

            public int CompareTo(object obj)
            {
                if (this == null) return -1;

                Māja cits = obj as Māja;
                return this.NIN_aprekins().CompareTo(cits.NIN_aprekins());
            }
        }
        static void Main(string[] args)
        {
            bool stop = false;
            Māja[] ieraksti = new Māja[10]
            {
                new Māja("Jelgava", "Lielā iela", "15", 10, 12, 1200),
                new Māja("Rīga", "Brīvības iela", "102A", 15, 20, 800),
                new Māja("Liepāja", "Dzintaru iela", "4", 8, 10, 600),
                new Māja("Ventspils", "Ostgala iela", "22", 12, 14, 1500),
                new Māja("Valmiera", "Rīgas iela", "7", 9, 11, 900),
                new Māja("Cēsis", "Pils iela", "3B", 7, 8, 500),
                new Māja("Ogre", "Meža prospekts", "19", 11, 13, 2000),
                new Māja("Sigulda", "Gaujas iela", "8", 14, 15, 1800),
                new Māja("Jūrmala", "Jomas iela", "45", 16, 18, 2500),
                new Māja("Daugavpils", "Vienības iela", "11", 10, 10, 1000)
            };
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
                            Array.Sort(ieraksti);
                            Console.WriteLine("Saraksts sakārtots!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            izvaditsarakstu(ieraksti);
                            Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                            Console.ReadKey();
                            Console.Clear();
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
        static void izvaditsarakstu(Māja[] majas)
        {
            foreach (Māja ieraksts in majas)
            {
                Console.WriteLine($"Pilsēta:{ieraksts.pilseta} | Ielas nosaukums: {ieraksts.ielas_nos} | " +
                    $" Ielas numurs: {ieraksts.ielas_nr} | Pilnā adrese: {ieraksts.adrese} | " +
                    $"Platums: {ieraksts.platums} | Garums: {ieraksts.garums} | " +
                    $"Zemes platība: {ieraksts.zemes_plat} | NĪN nodoklis: {ieraksts.NIN_aprekins()} EUR/gadā");
            }
        }
    }
}
