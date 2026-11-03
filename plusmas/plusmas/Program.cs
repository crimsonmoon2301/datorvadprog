using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace plusmas
{

    // Izvades atšķirības: Vienmēr tiek sākts ar x plūsmu, jo tā atrodas galvenajā plūsmā.
    // Dažreiz programma beidzas ar x plūsmu kā pēdējo, vai arī y kā pēdējo.
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Go);
            t.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("x");
            }
        }
        static void Go()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("\ty");
            }
        }
    }
}
