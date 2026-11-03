using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threads3
{
    internal class Program
    {
        static bool stop = false;

        // Priekš lock demonstrēšanas
        static readonly object locker = new object();
        static bool done = false;

        // Priekš manualresetevent demonstrēšanas
        private static ManualResetEvent manualreseteventObj = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            while (!stop)
            {
                Console.WriteLine("=====Fotosalons=====\n");

                Console.WriteLine("Izvēlies savu darbību: ");
                Console.WriteLine("1. Demonstrēt Join (Filmu attīstīšana)");
                Console.WriteLine("2. Demonstrēt Sleep un lock (Tumšās telpas izmantošana)");
                Console.WriteLine("3. Demonstrēt ManualResetevent (Grupu fotosesijas zibspuldze)");
                Console.WriteLine("4. Demonstrēt CountdownResetEvent (Fotoalbuma komplektēšana)");
                Console.WriteLine("5. Demonstrēt Thread priority ar bilžu apstrādi klientiem");
                Console.WriteLine("6. Demonstrēt Mutex ar salona kases aparātu");
                Console.WriteLine("7. Iziet\n");

                Console.Write("Tava darbība: ");
                string darb = Console.ReadLine();
                bool check = int.TryParse(darb, out int der);
                if (!check)
                {
                    Console.WriteLine("Tev jāievada cipars!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (der)
                    {
                        case 1:
                            Thread t = new Thread(Go);
                            t.Start();
                            t.Join();
                            Console.WriteLine("Filma attīstīta. Pasūtījumu var atstāt izžūšanai");
                            Console.ReadKey();
                            Console.Clear();
                            void Go()
                            {
                                for (int i = 0; i < 32; i++)
                                {
                                    Console.WriteLine($"Apstrādāts foto [{i+1}] no filmiņas");
                                }
                            }
                            break;
                        case 2:
                            Thread locksleepdemo = new Thread(sleepdemo) { Name = "Fotogrāfs 1"};
                            Thread locksleepdemo1 = new Thread(sleepdemo) { Name = "Fotogrāfs 2"};
                            locksleepdemo.Start();
                            locksleepdemo1.Start();
                            void sleepdemo()
                            {
                                string tname = Thread.CurrentThread.Name;
                                lock (locker)
                                {
                                    if (!done)
                                    {
                                        Console.WriteLine("Inicializē lock");
                                        Console.WriteLine($"Tagad {tname} izmanto tumšo telpu filmu apstrādei.");
                                        Thread.Sleep(1000);
                                        Console.WriteLine($"{tname} attīsta fotoplati. Netraucēt!");
                                        Thread.Sleep(2000);

                                        done = true;
                                        Console.WriteLine($"{tname} beidza darbu un tumšā telpa gatava lietošanai.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{tname} konstatē, ka pirmais fotogrāfs tikko beidza darbu");
                                    }
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            
                            void resetdemo()
                            {
                                string tname = Thread.CurrentThread.Name;
                                Console.WriteLine($"{tname} sagatavojas un gaida zibspuldzes signālu");
                                manualreseteventObj.WaitOne();

                                Console.WriteLine($"{tname} izlēma atpūsties pēc fotokadra");
                                Thread.Sleep(2000);

                                Console.WriteLine($"{tname} sagaida nākamo zibspuldzes signālu pēc atpūtas");
                                manualreseteventObj.WaitOne();

                                Console.WriteLine($"{tname} nobildējās un beidz fotosesiju.");
                            }
                            Thread manualresetdemo = new Thread(resetdemo) { Name = "Modele 1" };
                            Thread manualresetdemo1 = new Thread(resetdemo) { Name = "Modelis 2" };
                            Thread manualresetdemo2 = new Thread(resetdemo) { Name = "Modelis 3" };

                            manualresetdemo.Start();
                            manualresetdemo1.Start();
                            manualresetdemo2.Start();

                            Thread.Sleep(1500);
                            Console.WriteLine("\n--> Fotogrāfs nospiež zibspuldzi (Set())");
                            manualreseteventObj.Set();

                            Thread.Sleep(100);
                            manualreseteventObj.Reset();
                            Console.WriteLine("--> Fotogrāfs sagatavo un uzlādē zibspuldzi (Reset())\n");

                            Thread.Sleep(2000);
                            Console.WriteLine("--> Fotogrāfs atkal nospiež zibspuldzi (Set())");
                            manualreseteventObj.Set();

                            manualresetdemo.Join();
                            manualresetdemo1.Join();
                            manualresetdemo2.Join();
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        case 4:
                            // Norāda, ka jāgaida 3 signāli, pirms notikums atbloķējas
                            CountdownEvent countdown = new CountdownEvent(3);

                            void countdownDemo(object sleepTime)
                            {
                                string tName = Thread.CurrentThread.Name;
                                Console.WriteLine($"Fotogrāfs sāk apstrādāt foto ar {tName} funkciju no fotoapstrādes programmatūras");

                                Thread.Sleep((int)sleepTime); // Katra plūsma strādā savu laiku

                                Console.WriteLine($"{tName} apstrādes programmatūrā beidza darbu un parāda rezultātu uz ekrāna (Signal())");
                                countdown.Signal();
                            }

                            Thread c1 = new Thread(countdownDemo) { Name = "Objektīvu korekcijas" };
                            Thread c2 = new Thread(countdownDemo) { Name = "Krāsu korekcijas" };
                            Thread c3 = new Thread(countdownDemo) { Name = "Vāku sagatavošana" };

                            c1.Start(1000); // Strādā 1 sekundi
                            c2.Start(2000); // Strādā 2 sekundes
                            c3.Start(3000); // Strādā 3 sekundes

                            countdown.Wait(); // Gaida, kamēr skaitītājs no 3 nokrīt uz 0

                            Console.WriteLine("\n--> Visi 3 etapi gatavi. Apstrādātās kāzu fotogrāfijas tiek sūtītas izdrukai.");

                            c1.Join();
                            c2.Join();
                            c3.Join();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            bool isRunning = true;

                            void priorityDemo()
                            {
                                long count = 0;
                                // Kamēr karodziņš ir true, plūsma nepārtraukti skaita
                                while (isRunning)
                                {
                                    count++;
                                }
                                Console.WriteLine($"Fotogrāfs, kurš nodarbojās ar {Thread.CurrentThread.Name} (Prioritāte: {Thread.CurrentThread.Priority}) apstrādāja {count} pikseļus");
                            }

                            Thread p1 = new Thread(priorityDemo) { Name = "Portretu apstrādi"};
                            Thread p2 = new Thread(priorityDemo) { Name = "Kāzu fotogrāfiju albuma apstrādi"};
                            Thread p3 = new Thread(priorityDemo) { Name = "Dokumenta fotogrāfiju apstrādi"};
                            Thread p4 = new Thread(priorityDemo) { Name = "Ģimenes foto albumu komplektāciju"};
                            p1.Priority = ThreadPriority.Lowest;
                            p2.Priority = ThreadPriority.Highest;
                            p3.Priority = ThreadPriority.AboveNormal;
                            p4.Priority = ThreadPriority.BelowNormal;
                            //Thread p5 = new Thread(priorityDemo) { Name = "Plūsma 5", Priority = ThreadPriority.BelowNormal };
                            //Thread p6 = new Thread(priorityDemo) { Name = "Plūsma 6", Priority = ThreadPriority.AboveNormal };

                            Console.WriteLine("4 fotogrāfi sāk apstrādāt dažādas prioritātes foto pasūtījumus uz 15 sekundēm...\n");

                            p1.Start();
                            p2.Start();
                            p3.Start();
                            p4.Start();
                            //p5.Start();
                            //p6.Start();

                            Thread.Sleep(15000);
                            isRunning = false;  // Apturam ciklu visām plūsmām vienlaicīgi
                            p1.Join();
                            p2.Join();
                            p3.Join();
                            p4.Join();
                            //p5.Join();
                            ///p6.Join();

                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                            Mutex mutex = new Mutex();
                            int bilance = 1000;

                            void mutexDemo()
                            {
                                string tName = Thread.CurrentThread.Name;
                                while (!mutex.WaitOne(500))
                                {
                                    Console.WriteLine($"   [{tName}] mēģināja piekļūt, bet kases aparāts ir aizņemts! Mēģinās vēlreiz");
                                }
                                try
                                {
                                    Console.WriteLine($"[{tName}] tika pie kases un apskatījās pieejamos līdzekļus. Kases bilance: {bilance}");
                                    Thread.Sleep(1500);
                                    bilance -= 200;
                                    Console.WriteLine($"[{tName}] noņēma 200 EUR priekš materiāliem no kases, atlikums: {bilance}\n");
                                }
                                finally
                                {
                                    mutex.ReleaseMutex(); // Obligāti jāatbrīvo, lai nākamā plūsma tiktu iekšā
                                }
                            }

                            Thread mtx1 = new Thread(mutexDemo) { Name = "Fotogrāfs 1" };
                            Thread mtx2 = new Thread(mutexDemo) { Name = "Fotogrāfs 2" };
                            Thread mtx3 = new Thread(mutexDemo) { Name = "Fotogrāfs 3" };

                            mtx1.Start();
                            mtx2.Start();
                            mtx3.Start();

                            mtx1.Join();
                            mtx2.Join();
                            mtx3.Join();

                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 7:
                            stop = true;
                            break;
                        default:
                            Console.WriteLine("Tāda opcija šeit nav!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }

            }
        }
    }
}
