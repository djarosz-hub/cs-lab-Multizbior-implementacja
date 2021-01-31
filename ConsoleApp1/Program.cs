using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] znaki = new char[] {'a','a','a','b','c','c','d','e','e'};
            var mz = new MultiSet<char>(znaki);
            //Console.WriteLine(mz.ToString());
            //foreach(var x in mz)
            //    Console.WriteLine(x);
            //var tempintersect = new char[] { 'a', 'e','x' };
            //var tempMS = mz.SymmetricExceptWith(tempintersect);
            //Console.WriteLine("---");
            //foreach (var x in tempMS)
            //    Console.WriteLine(x);

            //var tempintersect = new char[] { 'a', 'b', 'c', 'd', 'e', 'x' };
            //Console.WriteLine(mz.IsProperSubsetOf(tempintersect));
            //char[] znaki1 = new char[] { 'a', 'a', 'a', 'b', 'c', 'c', 'd', 'e', 'e', 'x' };
            //Console.WriteLine(mz.MultiSetEquals(znaki1));
            Console.WriteLine(mz.ToString());
            //char[] znakX = new char[] { 'x', 'X' };
            //var mz2 = new MultiSet<char>(znakX);
            //Console.WriteLine(mz2.ToString());
            ////Console.WriteLine(mz.MultiSetEquals(mz2));
            //var newMsPlus = mz2 + mz;
            //Console.WriteLine(newMsPlus.ToString());
            char[] toMinus = new char[] { 'a', 'b','x' };
            var mz3 = new MultiSet<char>(toMinus);
            //var newMsMinus = mz - mz3;
            //Console.WriteLine(newMsMinus);
            var mz4 = mz * mz3;
            Console.WriteLine(mz4);
            //mz.IntersectWith(mz3);
            //Console.WriteLine(mz);

        }
    }
}
