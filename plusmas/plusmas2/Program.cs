using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace plusmas2
{
    //Paralēlā izpilde: Kad tiek izsaukts t.Start(),
    //operētājsistēma sāk pārvaldīt divus neatkarīgus izpildes ceļus vienlaikus – galveno pavedienu (Main),
    //kas drukā T2, un jauno pavedienu (Go), kas drukā T1.

    //Tā kā procesora slodze, sistēmas fona procesi un pavedienu pārslēgšanās (context switching) brīži katrā programmas palaišanas reizē atšķiras,
    //T1 un T2 rindas ekrānā sajaucas dažādās secībās un nevienā reizē nav pilnīgi vienādas.
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Go);
            t.Start();
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("\tT2");
            }

        }
        static void Go()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("T1");
            }
        }
    }
}
