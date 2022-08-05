using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousCSharpCode.TaskParallelLibrary
{
    internal class TaskContinuation
    {
        //MapProcessReduce
        public static void Main(string[] args)
        {
            string sentence = "the quick brown fox jumped over the lazy dog";

            //setup map reduce process
            var task = Task<string[]>.Factory.StartNew(() => Map(sentence))
                .ContinueWith<string[]>(t => Process(t.Result))
                .ContinueWith<string>(t => Reduce(t.Result));

            //display result
            Console.WriteLine("Result: {0}", task.Result);
        }

        private static string[] Map(string sentence)
        {
            return sentence.Split();
        }

        private static string[] Process(string[] words)
        {
            for(int i = 0; i < words.Length; i++)
            {
                int index = i;
                Task.Factory.StartNew(
                    () => words[index] = ReverseString(words[index]),
                    TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning
                    );
            }

            return words;
        }

        private static string ReverseString(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
                sb.Append(s[i]);
            return sb.ToString();
        }

        private static string Reduce(string[] words)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string word in words)
            {
                sb.Append(word);
                sb.Append(' ');
            }
            return sb.ToString();
        }
    }
}
