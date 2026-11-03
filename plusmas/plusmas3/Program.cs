using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace plusmas3
{
    internal class Program
    {
        // Plūsma t tiek atzīmēta kā fona plūsma. Kad beidzas galvenā plūsma, .NET aizver visus pavedienus.
        // Ņemot vērā arī to, ka ir IsBackground = true, plūsma tiek apturēta pirms vispār pabeidz darbu.
        static void Main(string[] args)
        {
            Thread t = new Thread(Go);
            t.IsBackground = true;
            t.Start();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("\tT2");
            }

        }
        static void Go()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("T1");
            }
        }
    }
}
