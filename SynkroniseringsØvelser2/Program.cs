using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynkroniseringsØvelser2
{
    internal class Program
    {
        static int counter = 0;
        static readonly object obj = new object();

        public void Stjerner()
        {
            Monitor.Enter(obj);
            try
            {
                counter += 60;
                Console.WriteLine($"******************************************************************************* {counter}\n");
            }
            finally
            {
                Monitor.Exit(obj);
            }
            Thread.Sleep(50);
        }
        public void HaveLåge()
        {
            Monitor.Enter(obj);
            try
            {
                counter += 60;
                Console.WriteLine($"############################################################################### {counter}\n");
            }
            finally
            {
                Monitor.Exit(obj);
            }
            Thread.Sleep(50);
        }

        static void Main(string[] args)
        {
            Program pg = new Program();
            for (int i = 0; i < 2; i++)
            {
                Thread t1 = new Thread(pg.Stjerner);
                t1.Start();
               
                Thread t2 = new Thread(pg.HaveLåge);
                t2.Start();
            }
            Console.Read();
        }
    }
}
