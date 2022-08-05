using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.LocksAndSynchronization
{
    internal class ThreadSynchronization
    {
        // shared field for work result
        public static int result = 0;

        // lock handle for shared result
        private static object lockHandle = new object();

        #region ...
        // event wait handles
        public static EventWaitHandle readyForResult = new AutoResetEvent(false);
        public static EventWaitHandle setResult = new AutoResetEvent(false);
		#endregion

		public static void DoWork()
		{
			while (true)
			{
				int i = result;

				// simulate long calculation
				Thread.Sleep(1);

				#region ...
				// wait until main loop is ready to receive result
				readyForResult.WaitOne();
				#endregion

				// return result
				lock (lockHandle)
				{
					result = i + 1;
				}

				#region ...
				// tell main loop that we set the result
				setResult.Set();
				#endregion
			}
		}

		public static void Main(string[] args)
		{
			// start the thread
			Thread t = new Thread(DoWork);
			t.Start();

			// collect result every 10 milliseconds
			for (int i = 0; i < 100; i++)
			{
				#region ...
				// tell thread that we're ready to receive the result
				readyForResult.Set();
				#endregion

				#region ...
				// wait until thread has set the result
				setResult.WaitOne();
				#endregion

				lock (lockHandle)
				{
					Console.WriteLine(result);
				}

				// simulate other work
				Thread.Sleep(10);
			}
		}
	}
}
