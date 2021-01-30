﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class MultiSet<T> : IEnumerable<T>
    {
        private Dictionary<T, int> mset = new Dictionary<T, int>();
        public MultiSet() { }
        public MultiSet(IEnumerable<T> data)
        {
            foreach (var el in data)
            {
                this.Add(el);
            }
        }
        public int Count
        {
            get
            {
                int cnt = 0;
                foreach (var (item, multiplicity) in mset)
                {
                    for (int i = 0; i < multiplicity; i++)
                        cnt++;
                }
                return cnt;
            }
        }
        public int this[T item] => mset[item];
        public bool IsEmpty => Count == 0; 
        public bool IsReadOnly => false;
        public void Add(T item)
        {
            IsMultiSetReadonly(this);
            if (!mset.ContainsKey(item))
            {
                mset.Add(item, 1);
                Console.WriteLine($"Added new item to multiSet: {item}");
            }
            else
                mset[item]++;
        }
        public MultiSet<T> Add(T item, int numberOfItems = 1)
        {
            IsMultiSetReadonly(this);
            for (int i = 0; i < numberOfItems; i++)
                this.Add(item);
            return this;
        }
        public bool Remove(T item)
        {
            IsMultiSetReadonly(this);
            if (!mset.ContainsKey(item))
                return false;
            if (mset[item] > 1)
            {
                mset[item]--;
                return true;
            }
            else
            {
                mset.Remove(item);
                return true;
            }
        }
        public MultiSet<T> Remove(T item, int numberOfItems = 1)
        {
            IsMultiSetReadonly(this);
            if (mset[item] < numberOfItems)
                numberOfItems = mset[item];
            if (mset.ContainsKey(item))
            {
                for (int i = 0; i < numberOfItems; i++)
                    this.Remove(item);
            }
            return this;
        }
        public MultiSet<T> RemoveAll(T item)
        {
            IsMultiSetReadonly(this);
            if (mset.ContainsKey(item))
                mset.Remove(item);
            return this;
        }
        public void Clear() => mset.Clear();
        public bool Contains(T item) => mset.ContainsKey(item);

        public MultiSet<T> UnionWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            IsMultiSetReadonly(this);
            foreach (var el in other)
                this.Add(el);
            return this;
        }
        public MultiSet<T> ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            IsMultiSetReadonly(this);
            foreach(var otherEl in other)
            {
                if (!mset.ContainsKey(otherEl))
                    continue;
                RemoveAll(otherEl);
            }
            return this;
        }
        public MultiSet<T> IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            IsMultiSetReadonly(this);
            List<T> tempList = new List<T>(other);
            foreach(var el in mset)
            {
                if (tempList.Contains(el.Key))
                    continue;
                RemoveAll(el.Key);
            }
            return this;
        }
        public MultiSet<T> SymmetricExceptWith(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            IsMultiSetReadonly(this);

            return this;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            List<T> tempList = new List<T>();
            foreach(var x in this)
            {
                tempList.Add(x);
            }
            tempList.CopyTo(array, arrayIndex);
        }
        public IReadOnlyDictionary<T, int> AsDictionary() => mset;
        //public IReadOnlySet<T> AsSet() CAN'T ACCESS REFERENCE
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var (item, multiplicity) in mset)
            {
                for (int i = 0; i < multiplicity; i++)
                    yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (var (item, multiplicity) in mset)
            {
                for (int i = 0; i < multiplicity; i++)
                    output.Append($"{item}, ");
            }
            return output.ToString(0, output.Length - 2);
        }
        public static MultiSet<T> Empty => new MultiSet<T>();
        public static bool IsMultiSetReadonly(MultiSet<T> ms) => ms.IsReadOnly == true ? throw new NotSupportedException() : false;
    }
}
//public override string ToString()
//{
//    StringBuilder output = new StringBuilder();
//    foreach (var (item, multiplicity) in mset)
//    {
//        output.Append($"{item}: {multiplicity}, ");
//    }
//    return output.ToString(0,output.Length-2);
//}

//private class MsetEnumerator : IEnumerator<T>
//{
//    public T Current => throw new NotImplementedException();
//    public bool MoveNext()
//    {
//        throw new NotImplementedException();
//    }
//    object IEnumerator.Current => Current;
//    public void Dispose()
//    {
//        throw new NotImplementedException();
//    }
//    public void Reset()
//    {
//        throw new NotImplementedException();
//    }
//}