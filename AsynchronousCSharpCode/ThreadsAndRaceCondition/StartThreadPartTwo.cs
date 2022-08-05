using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.ThreadsAndRaceCondition
{
    public class StartThreadPartTwo
    {
        private const int REPETITIONS = 100;

        public static void DoWork()
        {
            for (int i = 0; i < REPETITIONS; i++)
            {
                Console.Write("B");
            }
        }

        public static void Main(string[] args)
        {
            //start 10 new threads
            for (int i = 0; i < 9; i++)
            {
                Thread th = new Thread(DoWork);
                th.Name = "Thread" + i.ToString();
                th.Start();
            }

            //Line for breakpoint
            int dummy = 123;
        }
    }
}
