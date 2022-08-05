using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.ThreadsAndRaceCondition
{
    public class RaceCondition
    {
        public static void Main(string[] args)
        {
            Thread th = new Thread(DoWork);
            th.Start();

            //Display 5 additional stars
            DoWork();
        }

        private static void DoWork()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("*");
            }
        }
    }
}
