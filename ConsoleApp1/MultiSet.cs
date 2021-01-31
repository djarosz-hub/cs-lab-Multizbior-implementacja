using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class MultiSet<T> : IEnumerable<T>
    {
        private Dictionary<T, int> mset = new Dictionary<T, int>();
        public MultiSet() { }
        public MultiSet(IEnumerable<T> sequence)
        {
            foreach (var el in sequence)
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
            IsMultiSetReadonly(this);
            NotNullReturnsList(other, out List<T>tempList);
            foreach(var el in mset)
            {
                if (tempList.Contains(el.Key))
                    continue;
                RemoveAll(el.Key);
            }
            foreach(var el in mset.ToList())
            {
                mset[el.Key] = 1;
            }
            return this;
        }
        public MultiSet<T> SymmetricExceptWith(IEnumerable<T> other)
        {
            IsMultiSetReadonly(this);
            NotNullReturnsList(other, out List<T> tempList);
            foreach (var el in mset)
            {
                if (tempList.Contains(el.Key))
                {
                    RemoveAll(el.Key);
                    tempList.Remove(el.Key);
                }
            }
            this.UnionWith(tempList);
            return this;
        }
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            foreach (var el in mset)
            {
                if (!tempList.Contains(el.Key))
                    return false;
            }
            return true;
        }
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            if (IsSubsetOf(other) && tempList.Count > this.Count)
                return true;
            return false;
        }
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            foreach(var el in tempList)
            {
                if (!mset.ContainsKey(el))
                    return false;
            }
            return true;
        }
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            if (IsSupersetOf(other) && this.Count > tempList.Count)
                return true;
            return false;
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
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
                throw new ArgumentNullException();
            foreach(var el in other)
            {
                if (mset.ContainsKey(el))
                    return true;
            }
            return false;
        }
        public bool MultiSetEquals(IEnumerable<T> other)
        {
            NotNullReturnsList(other, out List<T> tempList);
            var groupedList = tempList.GroupBy(el => el);
            foreach(var el in groupedList)
            {
                //Console.WriteLine(el.Key + " " + el.Count());
                if (!mset.ContainsKey(el.Key))
                    return false;
                if (mset[el.Key] != el.Count())
                    return false;
            }
            //Console.WriteLine("after loop");
            //Console.WriteLine(IsProperSubsetOf(other));
            //Console.WriteLine(IsProperSupersetOf(other));
            return !IsProperSubsetOf(other) && !IsProperSupersetOf(other);
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
            if (output.Length == 0)
                return "Multiset is empty";
            return output.ToString(0, output.Length - 2);
        }
        private void NotNullReturnsList(IEnumerable<T> other, out List<T> tempList)
        {
            if(other == null)
                throw new ArgumentNullException();
            tempList = new List<T>(other);
        }
        public static MultiSet<T> Empty => new MultiSet<T>();
        public static MultiSet<T> operator +(MultiSet<T> first, MultiSet<T> second)
        {
            first.NotNullReturnsList(first, out List<T> tempList1);
            second.NotNullReturnsList(second, out List<T> tempList2);
            var listToCreate = tempList1.Concat(tempList2);
            return new MultiSet<T>(listToCreate);
        }
        public static MultiSet<T> operator -(MultiSet<T> first, MultiSet<T> second)
        {
            first.NotNullReturnsList(first, out List<T> tempList1);
            second.NotNullReturnsList(second, out List<T> tempList2);
            var newSet = new MultiSet<T>(tempList1);
            foreach(var item in tempList2)
            {
                newSet.RemoveAll(item);
            }
            return newSet;
        }
        public static MultiSet<T> operator *(MultiSet<T> first, MultiSet<T> second)
        {
            first.NotNullReturnsList(first, out List<T> tempList1);
            second.NotNullReturnsList(second, out List<T> tempList2);
            var newSet = new MultiSet<T>(tempList1);
            newSet.IntersectWith(tempList2);
            return newSet;
        }

        public static bool IsMultiSetReadonly(MultiSet<T> ms) => ms.IsReadOnly == true ? throw new NotSupportedException() : false;
    }
}