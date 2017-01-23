using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTrackingSystem
{
    class PrintingSystem
    {

        public static void WriteCenteredLine(string stringVariable)
        {
            int x;
            x = ((Console.WindowWidth + stringVariable.Length) / 2);
            Console.WriteLine("{0," + x + "}", stringVariable);
        }
    }
}
