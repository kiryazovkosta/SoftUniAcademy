namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private readonly Stack<T> items;

        public Box()
        {
            this.items = new Stack<T>();
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Add(T element)
        {
            this.items.Push(element);
        }

        public T Remove()
        {
            return this.items.Pop();
        }
    }
}