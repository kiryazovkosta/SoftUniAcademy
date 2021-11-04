using System;
using System.Collections.Generic;
using System.Text;

namespace Hierarchy
{
    public class MyList<T> : IAddable<T>, IRemovable<T>, IUsedable
    {
        private List<T> elements;

        public MyList()
        {
            this.elements = new List<T>();
        }

        public int Used => throw new NotImplementedException();

        public int Add(T element)
        {
            this.elements.Insert(0, element);
            return 0;
        }

        public T Remove()
        {
            T element = this.elements[0];
            this.elements.Remove(element);
            return element;
        }
    }
}
