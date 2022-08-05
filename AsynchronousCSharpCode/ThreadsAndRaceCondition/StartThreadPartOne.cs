using System;
using System.Threading;

namespace AsynchronousCSharpCode.ThreadsAndRaceCondition
{
    public class StartThreadPartOne
    {
        public static void Main(string[] args)
        {
            //start background thread
            Thread th = new Thread(() =>
            {
                Console.WriteLine("Thread is starting, press ENTER to continue");
                Console.ReadLine();
            });
            th.IsBackground = false;
            th.Start();
        }
    }
}
