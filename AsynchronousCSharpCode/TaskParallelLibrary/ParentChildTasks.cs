using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.TaskParallelLibrary
{
    internal class ParentChildTasks
    {
        public static List<Task<string>> tasks = new List<Task<string>>();

        public static string ReverseString(string word)
        {
            Thread.Sleep(1000);
            StringBuilder sb = new StringBuilder();
            for (int i = word.Length - 1; i >=0; i--)
            {
                 sb.Append(word[i]);
            }
            return sb.ToString();
        }

        public static void ReverseSentence(string sentence)
        {
            foreach(string word in sentence.Split())
            {
                tasks.Add(Task<string>.Factory.StartNew(() => ReverseString(word) + " ",
                    TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning));
            }
        }

        public static void Main(string[] args)
        {
            string sentence = "the quick brown fox jumped over the lazy dog";

            // run parent tasks to process sentence
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task.Factory.StartNew( () => ReverseString(sentence)).Wait();
            sw.Stop();
            Console.WriteLine("Total runtime: {0}ms", sw.ElapsedMilliseconds);

            #region verify that all tasks have completed
            for (int i = 0; i < tasks.Count; i++)
                Console.WriteLine("Task {0} complete: {1}",
                                  i, tasks[i].IsCompleted);
            #endregion

            // display result
            Console.Write("Result: ");
            foreach (Task<string> t in tasks)
                Console.Write(t.Result);
        }
    }
}
