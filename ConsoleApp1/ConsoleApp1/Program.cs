using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        // Delegāti strādā tā, ka funkcijas var strādāt kā objekti, kas padod apstrādā, kā arī padod vērtības tālāk.
        // Delegāti atvieglo funkciju izpildi, vienlaikus arī padarot kodu vienkāršāku.
        // 
        public static bool stop = false;
        delegate double Matematika(double a, double b);

        public static double Saskaitit(double a, double b)
        {
            return a + b;
        }
        public static double Atnemt(double a, double b)
        {
            return a - b;
        }
        public static double Dalit(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Kļūda! Otrais skaitlis nedrīkst būt nulle! Pirmais skaitlis tiks izmantots kā rezultāts");
                return a;
            }
            else
            {
                return a / b;
            }
        }
        public static double Reizinat(double a, double b)
        {
            return a * b;
        }
        public static double Kvadratsakne(double a, double b)
        {
            return Math.Sqrt(a);
        }
        public static double Kapinasana(double a, double b)
        {
            return Math.Pow(a, b);
        }
        static double result;
        static void Main(string[] args)
        {
            Matematika del = null;
            while (!stop)
            {
                Console.WriteLine("Izvēlies darbību:");
                Console.WriteLine("1 - Saskaitīt");
                Console.WriteLine("2 - Atņemt");
                Console.WriteLine("3 - Dalīt");
                Console.WriteLine("4 - Reizināt");
                Console.WriteLine("5 - Kvadrātsakne (a)");
                Console.WriteLine("6 - Kāpina (a^b)");
                Console.WriteLine("0 - Iziet");
                Console.Write("Tava opcija: ");
                bool izvelne = int.TryParse(Console.ReadLine(), out int opcija);
                if (!izvelne)
                {
                    Console.WriteLine("Nepareiza opcija!");
                    continue;
                }
                else
                {
                    switch (opcija)
                    {
                        case 1:
                            Console.Clear();
                            if (del == null)
                            {
                                Console.Write("Ievadi pirmo skaitli: ");
                                double pirmais = Convert.ToDouble(Console.ReadLine());
                                Console.Write("\nIevadi otro skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Saskaitit;
                                result = del(pirmais, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                               
                            }
                            else
                            {
                                Console.Write($"Iepriekšējais rezultāts: {result}");
                                Console.Write("\nIevadi jauno skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Saskaitit;
                                result = del(result, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                           
                            break;
                        case 2:
                            Console.Clear();
                            if (del == null)
                            {
                                Console.Write("Ievadi pirmo skaitli: ");
                                double pirmais = Convert.ToDouble(Console.ReadLine());
                                Console.Write("\nIevadi otro skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Atnemt;
                                result = del(pirmais, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            else
                            {
                                Console.Write($"Iepriekšējais rezultāts: {result}");
                                Console.Write("\nIevadi jauno skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Atnemt;
                                result = del(result, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            break;
                        case 3:
                            Console.Clear();
                            if (del == null)
                            {
                                Console.Write("Ievadi pirmo skaitli: ");
                                double pirmais = Convert.ToDouble(Console.ReadLine());
                                Console.Write("\nIevadi otro skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Dalit;
                                result = del(pirmais, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            else
                            {
                                Console.Write($"Iepriekšējais rezultāts: {result}");
                                Console.Write("\nIevadi jauno skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Dalit;
                                result = del(result, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            break;
                        case 4:
                            Console.Clear();
                            if (del == null)
                            {
                                Console.Write("Ievadi pirmo skaitli: ");
                                double pirmais = Convert.ToDouble(Console.ReadLine());
                                Console.Write("\nIevadi otro skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Reizinat;
                                result = del(pirmais, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            else
                            {
                                Console.Write($"Iepriekšējais rezultāts: {result}");
                                Console.Write("\nIevadi jaunu skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Reizinat;
                                result = del(result, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            break;
                        case 5:
                            Console.Clear();
                            if (del == null)
                            {
                                Console.WriteLine("Ievadi skaitli ar ko vēlies izvilkt kvadrātsakni");
                                double sakne = Convert.ToDouble(Console.ReadLine());
                                del = Kvadratsakne;
                                result = del(sakne, double.NaN); // Padod vērtību b kā nan (nav vērtību)
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            else
                            {
                                Console.Write($"Iepriekšējais rezultāts: {result}\n");
                                del = Kvadratsakne;
                                result = del(result, double.NaN); // Padod vērtību b kā nan (nav vērtību)
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            break;
                        case 6:
                            Console.Clear();
                            if (del == null)
                            {
                                Console.Write("Ievadi pirmo skaitli: ");
                                double pirmais = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Ievadi otro skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Kapinasana;
                                result = del(pirmais, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            else
                            {
                                Console.Write($"Iepriekšējais rezultāts: {result}\n");
                                Console.Write("Ievadi otro skaitli: ");
                                double otrais = Convert.ToDouble(Console.ReadLine());
                                del = Kapinasana;
                                result = del(result, otrais);
                                Console.WriteLine($"Rezultāts: {result}");
                            }
                            break;
                        case 0:
                            Console.WriteLine("Programma tiek apturēta!");
                            stop = true;
                            break;
                        default:
                            Console.WriteLine("Nepareiza opcija!");
                            break;
                    }
                }
            }
        }
    }
}
