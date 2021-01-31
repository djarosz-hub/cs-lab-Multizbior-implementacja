using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System.Text;
using System.Collections.Generic;
using System;

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
    }
}
