using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] znaki = new char[] {'a','a','a','b','c','c','d','e','e'};
            var mz = new MultiSet<char>(znaki);
            Console.WriteLine(mz.ToString());
            foreach(var x in mz)
                Console.WriteLine(x);
            //var tempintersect = new char[] { 'a', 'e','x' };
            //var tempMS = mz.SymmetricExceptWith(tempintersect);
            //Console.WriteLine("---");
            //foreach (var x in tempMS)
            //    Console.WriteLine(x);

            //var tempintersect = new char[] { 'a', 'b', 'c', 'd', 'e', 'x' };
            //Console.WriteLine(mz.IsProperSubsetOf(tempintersect));
            //char[] znaki1 = new char[] { 'a', 'a', 'a', 'b', 'c', 'c', 'd', 'e', 'e', 'x' };
            //Console.WriteLine(mz.MultiSetEquals(znaki1));
            var mz2 = new MultiSet<char>(znaki);
            Console.WriteLine(mz.MultiSetEquals(mz2));

        }
    }
}
