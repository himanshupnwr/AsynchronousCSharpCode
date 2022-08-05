using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.LocksAndSynchronization
{
    internal class UsingMonitor
    {
        private static int value1 = 1;
        private static int value2 = 1;

        #region synchronization object
        private static object lockObj = new object();
        #endregion

        //thread work method
        public static void DoWork()
        {
            bool lockTaken = false;
            try
            {
                #region Monitor.TryEnter
                Monitor.TryEnter(lockObj, TimeSpan.FromMilliseconds(50), ref lockTaken);
                #endregion
                if (value2 > 0)
                {
                    Console.WriteLine(value1 / value2);
                    value2 = 0;
                }
            }
            finally
            {
                if(lockTaken)
                {
                    Monitor.Exit(lockObj);
                }
            }
        }

        public static void Main(string[] args)
        {
            //start two threads
            Thread t1 = new Thread(DoWork);
            Thread t2 = new Thread(DoWork);
            t1.Start();
            t2.Start();
        }
    }
}
