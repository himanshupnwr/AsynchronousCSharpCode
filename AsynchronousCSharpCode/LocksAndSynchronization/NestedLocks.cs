using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.LocksAndSynchronization
{
    internal class NestedLocks
    {
		// shared private fields
		private static int value1 = 1;
		private static int value2 = 1;

		// synchronisation object
		private static object syncObj = new object();

		// thread work method
		public static void DoWork()
		{
			lock (syncObj)
			{
				if (value2 > 0)
				{
					DoTheDivision();
					value2 = 0;
				}
			}
		}

		// helper method to do the division
		public static void DoTheDivision()
		{
			lock (syncObj)
			{
				Console.WriteLine(value1 / value2);
			}
		}

		public static void Main(string[] args)
		{
			// start two threads
			Thread t1 = new Thread(DoWork);
			Thread t2 = new Thread(DoWork);
			t1.Start();
			t2.Start();
		}
	}
}
