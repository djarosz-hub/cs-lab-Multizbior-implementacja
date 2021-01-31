using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParameterlessConstructorTest()
        {
            MultiSet<char> mschar = new MultiSet<char>();
            Assert.AreEqual(true, mschar.IsEmpty);
            Assert.AreEqual(0, mschar.Count);
            MultiSet<StringBuilder> ms = new MultiSet<StringBuilder>();
            Assert.AreEqual(true, ms.IsEmpty);
            Assert.AreEqual(0, ms.Count);
        }
        [TestMethod]
        public void CharSequenceConstructorTest()
        {
            char[] chars = new char[] { 'a', 'a', 'a', 'b', 'c', 'c', 'd', 'e', 'e' };
            MultiSet<char> mschar = new MultiSet<char>(chars);
            Assert.AreEqual(9, mschar.Count);
        }
        [TestMethod]
        public void StringBuilderSequenceTest()
        {
            StringBuilder sb = new StringBuilder("aaa");
            StringBuilder sb1 = new StringBuilder("bbb");
            StringBuilder sb2 = new StringBuilder("ccc");
            List<StringBuilder> list = new List<StringBuilder>() { sb, sb1, sb2 };
            MultiSet<StringBuilder> ms = new MultiSet<StringBuilder>(list);
            string output = "aaa, bbb, ccc";
            Assert.AreEqual(output, ms.ToString());
        }
        [DataTestMethod]
        [DataRow(5, 5)]
        [DataRow(0, 0)]
        [DataRow(100, 100)]
        public void CountTest(int intCount, int expected)
        {
            var list = new List<int>();
            var rnd = new Random();
            for (int i = 0; i < intCount; i++)
            {
                list.Add(rnd.Next());
            }
            var ms = new MultiSet<int>(list);
            Assert.AreEqual(expected, ms.Count);
        }

        [DataTestMethod]
        [DataRow(5, false)]
        [DataRow(0, true)]
        [DataRow(100, false)]
        public void IsEmptyTest(int intCount, bool expected)
        {
            var list = new List<int>();
            var rnd = new Random();
            for (int i = 0; i < intCount; i++)
            {
                list.Add(rnd.Next());
            }
            var ms = new MultiSet<int>(list);
            Assert.AreEqual(expected, ms.IsEmpty);
        }

        [TestMethod]
        public void AddCharTest()
        {
            char[] chars = new char[] { 'a', 'a', 'a', 'b', 'c', 'c', 'd', 'e', 'e' };
            MultiSet<char> mschar = new MultiSet<char>();
            foreach (char c in chars)
                mschar.Add(c);
            string output = "a, a, a, b, c, c, d, e, e";
            Assert.AreEqual(output, mschar.ToString());
            Assert.AreEqual(9, mschar.Count);
        }
        [TestMethod]
        public void AddSBTest()
        {
            StringBuilder sb = new StringBuilder("aaa");
            StringBuilder sb1 = new StringBuilder("bbb");
            StringBuilder sb2 = new StringBuilder("ccc");
            List<StringBuilder> list = new List<StringBuilder>() { sb, sb1, sb2 };
            MultiSet<StringBuilder> ms = new MultiSet<StringBuilder>();
            foreach (var s in list)
            {
                ms.Add(s);
            }
            string output = "aaa, bbb, ccc";
            Assert.AreEqual(output, ms.ToString());
            Assert.AreEqual(3, ms.Count);
        }
        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(0, 0)]
        public void AddMoreCharsTest(int cnt, int expected)
        {
            MultiSet<char> mschar = new MultiSet<char>();
            mschar = mschar.Add('a', cnt);
            Assert.AreEqual(expected, mschar.Count);
        }
        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(0, 0)]
        public void AddMoreSBTest(int cnt, int expected)
        {
            MultiSet<StringBuilder> mschar = new MultiSet<StringBuilder>();
            mschar = mschar.Add(new StringBuilder("aa"), cnt);
            Assert.AreEqual(expected, mschar.Count);
        }
        [DataTestMethod]
        [DataRow(5, 2, 3)]
        [DataRow(1, 1, 0)]
        [DataRow(1, 10, 0)]
        public void RemoveChar(int itemsToAdd, int itemsToRemove, int expected)
        {
            char testChar = 'a';
            MultiSet<char> mschar = new MultiSet<char>();
            mschar = mschar.Add(testChar, itemsToAdd);
            for (int i = 0; i < itemsToRemove; i++)
            {
                mschar.Remove(testChar);
            }
            Assert.AreEqual(expected, mschar.Count);
        }
        [TestMethod]
        public void ClearMS()
        {
            MultiSet<char> mschar = new MultiSet<char>();
            mschar.Add('a');
            mschar.Clear();
            Assert.AreEqual(0, mschar.Count);
        }
        [TestMethod]
        public void MSContains()
        {
            MultiSet<char> mschar = new MultiSet<char>();
            mschar.Add('a');
            Assert.AreEqual(true, mschar.Contains('a'));
        }
        [TestMethod]
        public void MSNotContains()
        {
            MultiSet<char> mschar = new MultiSet<char>();
            mschar.Add('a');
            Assert.AreEqual(false, mschar.Contains('b'));
        }
        [TestMethod]
        public void UnionMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'x' };
            var ms2 = new MultiSet<char>(chars2);
            ms = ms.UnionWith(ms2);
            string output = "a, a, b, b, c, d, e, x";
            Assert.AreEqual(output, ms.ToString());
        }
        [TestMethod]
        public void ExceptMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'x' };
            var ms2 = new MultiSet<char>(chars2);
            ms = ms.ExceptWith(ms2);
            string output = "c, d, e";
            Assert.AreEqual(output, ms.ToString());
        }
        [TestMethod]
        public void IntersectMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'x' };
            var ms2 = new MultiSet<char>(chars2);
            ms = ms.IntersectWith(ms2);
            string output = "a, b";
            Assert.AreEqual(output, ms.ToString());
        }
        [TestMethod]
        public void SymmetricExceptMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'x' };
            var ms2 = new MultiSet<char>(chars2);
            ms = ms.SymmetricExceptWith(ms2);
            string output = "x, c, d, e";
            Assert.AreEqual(output, ms.ToString().Trim());
        }
        [TestMethod]
        public void IsSubsetMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(true, ms2.IsSubsetOf(ms));
        }
        [TestMethod]
        public void IsNotSubsetMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'x' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(false, ms2.IsSubsetOf(ms));
        }
        [TestMethod]
        public void IsProperSubsetMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(true, ms2.IsProperSubsetOf(ms));
        }
        [TestMethod]
        public void IsNotProperSubsetMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(false, ms2.IsProperSubsetOf(ms));
        }
        [TestMethod]
        public void IsSupersetMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(true, ms.IsSupersetOf(ms2));
        }
        [TestMethod]
        public void IsNotSupersetMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'x' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(false, ms.IsSupersetOf(ms2));
        }
        [TestMethod]
        public void IsProperSupersetMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(true, ms.IsProperSupersetOf(ms2));
        }
        [TestMethod]
        public void IsNotProperSupersetMs()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(false, ms.IsProperSupersetOf(ms2));
        }
        [TestMethod]
        public void CopyToMs()
        {
            char[] chars = new char[] { 'a', 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] outputArr = new char[chars.Length];
            ms.CopyTo(outputArr, 0);
            Assert.AreEqual(string.Concat(chars), string.Concat(outputArr));
        }
        [TestMethod]
        public void OverlapsMs()
        {
            char[] chars = new char[] { 'a', 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] testChar = new char[] { 'a' };
            Assert.AreEqual(true, ms.Overlaps(testChar));
        }
        [TestMethod]
        public void NotOverlapsMs()
        {
            char[] chars = new char[] { 'a', 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] testChar = new char[] { 'x' };
            Assert.AreEqual(false, ms.Overlaps(testChar));
        }
        [TestMethod]
        public void MultiSetEqualsMs()
        {
            char[] chars = new char[] { 'a', 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'e', 'd', 'c', 'b', 'a','a'};
            var ms2 = new MultiSet<char>(chars);
            Assert.AreEqual(true, ms.MultiSetEquals(ms2));
        }
        [DataTestMethod]
        [DataRow("a, a", 'a','a')]
        [DataRow("Multiset is empty")]
        [DataRow("a, b, c", 'a', 'b','c')]
        public void ToStringMs(string output, params char[] args)
        {
            var ms = new MultiSet<char>(args);
            Assert.AreEqual(output, ms.ToString());
        }
        [TestMethod]
        public void EmptyMs()
        {
            var ms = MultiSet<char>.Empty;
            Assert.AreEqual(true, ms.IsEmpty);
        }
        [TestMethod]
        public void OperatorPlusMs()
        {
            char[] chars = new char[] { 'a', 'd'};
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'd', 'c'};
            var ms2 = new MultiSet<char>(chars2);
            var ms3 = ms + ms2;
            Assert.AreEqual("a, d, d, c", ms3.ToString());
        }
        [TestMethod]
        public void OperatorMinusMs()
        {
            char[] chars = new char[] { 'a', 'd' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'd', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            var ms3 = ms - ms2;
            Assert.AreEqual("a", ms3.ToString());
        }
        [TestMethod]
        public void OperatorMultiplyMs()
        {
            char[] chars = new char[] { 'a', 'd' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'd', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            var ms3 = ms * ms2;
            Assert.AreEqual("d", ms3.ToString());
        }
    }
}
