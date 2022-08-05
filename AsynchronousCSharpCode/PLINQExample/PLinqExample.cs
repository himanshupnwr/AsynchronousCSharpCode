using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.PLINQExample
{
    internal class PLinqExample
    {
        public static void Main(string[] args)
        {
            string sentence = "the quick brown fox jumped over the lazy dog ";

            var words = sentence.Split()
                .AsParallel()
                .AsOrdered()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Select(word => new string(word.Reverse().ToArray()));

            Console.WriteLine(string.Join("", words));
        }
    }
}