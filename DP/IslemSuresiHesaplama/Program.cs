using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IslemSuresiHesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            stopwatch.Stop();
            Console.WriteLine("Bağlantı kurulma süresi: {0}", stopwatch.Elapsed.Milliseconds);

            Console.ReadLine();
        }
    }

    

    
}
