namespace ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;

        private List<T> elements;

        public ListyIterator(params T[] elements)
        {
            this.index = 0;
            this.elements = new List<T>(elements);
        }

        public bool Move()
        {
            if (this.index < this.elements.Count - 1)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.elements.Count)
            {
                return true;
            }

            return false;
        }

        public T Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.elements[this.index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
