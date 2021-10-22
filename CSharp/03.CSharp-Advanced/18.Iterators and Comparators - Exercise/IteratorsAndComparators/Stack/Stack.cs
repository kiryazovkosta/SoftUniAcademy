using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> items;

        public Stack()
        {
            items = new List<T>();
        }

        public int Count => items.Count;

        public void Push(T element)
        {
            items.Add(element);
        }

        public T Pop()
        {
                T element = items[^1];
                items.RemoveAt(items.Count - 1);
                return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
