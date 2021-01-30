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
            var tempintersect = new char[] { 'a', 'e' };
            var tempMS = mz.IntersectWith(tempintersect);
            Console.WriteLine("---");
            foreach (var x in tempMS)
                Console.WriteLine(x);
        }
    }
}
