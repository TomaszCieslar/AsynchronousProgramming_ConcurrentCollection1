using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace AsynchronousProgramming_ConcurrentCollection1
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() => 
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrEmpty(s)) break;
                    {
                        col.Add(s);
                    }
                }
            });

            write.Wait();
            
        }
    }
}
