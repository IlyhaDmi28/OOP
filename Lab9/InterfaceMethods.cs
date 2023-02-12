using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public partial class Concert<T> : ISet<T>
    {
        public int Count { get; }
        public bool IsReadOnly { get; }
        public bool Add(T a)
        {
            return true;
        }
        public void Clear()
        {

        }
        public bool Contains(T a)
        {
            return true;
        }
        public void UnionWith(T a)
        {

        }
        public void ExceptWith(IEnumerable<T> a)
        {

        }
        public void UnionWith(IEnumerable<T> a)
        {

        }
        public void IntersectWith(IEnumerable<T> a)
        {

        }
        public void SymmetricExceptWith(IEnumerable<T> a)
        {

        }
        public bool IsSubsetOf(IEnumerable<T> a)
        {
            return true;
        }
        public bool IsSupersetOf(IEnumerable<T> a)
        {
            return true;
        }
        public bool IsProperSupersetOf(IEnumerable<T> a)
        {
            return true;
        }
        public bool IsProperSubsetOf(IEnumerable<T> a)
        {
            return true;
        }
        public bool Overlaps(IEnumerable<T> a)
        {
            return true;
        }
        public bool SetEquals(IEnumerable<T> a)
        {
            return true;
        }
        public void CopyTo(T[] a, int b)
        {

        }
        public bool Remove(T a)
        {
            return true;
        }
        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
