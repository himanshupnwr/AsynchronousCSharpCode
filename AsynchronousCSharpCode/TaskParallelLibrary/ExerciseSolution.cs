using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
namespace AsynchronousCSharpCode.TaskParallelLibrary
{
    public class Exercise
    {
        private static string ExecuteTransformation(string input)
        {
            var task = Task<string>.Factory.StartNew(
                () => PrepareCase(input))
                    .ContinueWith<string>(t => GoToTheBackOfTheLine(t.Result))
                        .ContinueWith<string>(t => Decorate(t.Result));

            return task.Result;
        }

        private static string PrepareCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            return input.ToLowerInvariant();
        }

        private static string GoToTheBackOfTheLine(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            string head = input.Substring(0, 1);
            string body = (input.Length > 1) ? input.Substring(1) : string.Empty;
            StringBuilder bldr = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(body)) bldr.Append(body);
            bldr.Append(head);
            return bldr.ToString();
        }

        private static string Decorate(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            StringBuilder bldr = new StringBuilder();
            bldr.Append(input);
            bldr.Append("ay");
            return bldr.ToString();
        }

        public static string[] Process(string[] input)
        {
            // Instantiate child tasks.
            for (int i = 0; i < input.Length; i++)
            {
                int index = i;
                Task.Factory.StartNew(
                    () => input[index] = ExecuteTransformation(input[index]),
                    TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
            }
            return input;
        }

        private static string[] Map(string input)
        {
            return input.Split();
        }

        private static string Reduce(string[] input)
        {
            if ((input == null) || (input.Length < 1))
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();

            foreach (string element in input)
            {
                if (!string.IsNullOrWhiteSpace(element)) sb.Append(element + " ");
            }

            return sb.ToString();
        }

        // TODO: complete this method - return the sentence as pig latin
        public static string PigLatin(string sentence)
        {
            if (sentence == null)    // <-- do the null and empty check here
                return null;
            else if (string.IsNullOrEmpty(sentence))
                return String.Empty;
            var task = Task<string[]>.Factory.StartNew(() => Map(sentence))
                .ContinueWith<string[]>(t => Process(t.Result))
                    .ContinueWith<string>(t => Reduce(t.Result));

            try
            {
                return task.Result.Trim();  // <-- don't forget to remove the final space
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return null;
            }
        }

        public static void Main(string[] args)
        {
            var response = PigLatin("Himanshu Panwar");
            Console.WriteLine(response);
        }
    }
}