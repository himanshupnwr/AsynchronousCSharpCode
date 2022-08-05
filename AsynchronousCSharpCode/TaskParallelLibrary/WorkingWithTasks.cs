using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.TaskParallelLibrary
{
    internal class WorkingWithTasks
    {
		public static void Main(string[] args)
		{
			// start new task
			var task = Task.Factory.StartNew(() => {

				Thread.Sleep(2000);
				Console.WriteLine("Hello World");

				#region thread information
				// Console.WriteLine ("Is background thread: {0}", Thread.CurrentThread.IsBackground);
				// Console.WriteLine ("Is threadpool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);
				#endregion

				#region throw exception
				throw new InvalidOperationException("Something went wrong");
				#endregion

			});

			// wait for task to complete
			task.Wait();
		}
	}
}
