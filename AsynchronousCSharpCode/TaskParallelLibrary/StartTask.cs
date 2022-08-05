using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.TaskParallelLibrary
{
    internal class StartTask
    {
        public static void main(string[] args)
        {
            var tasks = Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                return "This is a new task";
            });

            Console.WriteLine(tasks.Result);
        }
    }
}
