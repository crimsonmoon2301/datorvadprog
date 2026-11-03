using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace plusmas12
{
    class ThreadTest
    {
        // lock bloks strādā tā, ka ir "kritiskais bloks", kur var atrasties tikai viena plūsma.
        // Ja tiek viena plūsma, otra plūsma gaida tiklīdz atbrīvojas.

        // Ja nebūtu lock, abas plūsmas neapzinātos viens otra eksistenci un izpildītu Go() neatkarīgi no viens otra.
        static bool done;
        static readonly object locker = new object();

        static void Main(string[] args)
        {
            new Thread(Go).Start();
            Go();
        }
        static void Go()
        {
            lock (locker)
            {
                if (!done)
                {
                    Thread.Sleep(1);
                    done = true;
                    Console.WriteLine("Done");
                }
            }
        }
    }
}
