using System.Collections.Generic;

namespace Hierarchy
{
    public class AddRemoveCollection<T> : IAddable<T>, IRemovable<T>
    {
        private Queue<T> elements;

        public AddRemoveCollection()
        {
            this.elements = new Queue<T>();
        }

        public int Add(T element)
        {
            this.elements.Enqueue(element);
            return 0;
        }

        public T Remove()
        {
            T element = this.elements.Dequeue();
            return element;
        }
    }
}
