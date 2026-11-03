using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization.Formatters;

namespace plusmas13
{
    // Ar t.Join - Gaidīs kamēr Go() plūsma beigs darbību.
    // Bez - Negaidīs. Izvadīs "Thread t has ended" pašā sākumā, nevis beigās, kad Go() pabeidz ciklu.
    class ThreadTest
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Go);
            t.Start();
            t.Join();
            Console.WriteLine("Thread t has ended!");
        }
        static void Go()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("y");
            }
        }
    }
}
