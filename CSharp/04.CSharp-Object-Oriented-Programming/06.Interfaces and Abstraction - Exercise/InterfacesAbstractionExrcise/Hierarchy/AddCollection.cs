using System.Collections.Generic;

namespace Hierarchy
{
    public class AddCollection<T> : IAddable<T>
    {
        private readonly List<T> items;

        public AddCollection()
        {
            this.items = new List<T>();
        }

        public int Add(T element)
        {
            this.items.Add(element);
            return this.items.Count - 1;
        }
    }
}