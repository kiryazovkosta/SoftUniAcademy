using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private LinkedListItem first = null;
        private LinkedListItem last = null;

        private int Count
        {
            get
            {
                int count = 0;
                LinkedListItem item = first;
                while (item != null)
                {
                    count++;
                    item = item.Next;
                }

                return count;
            }
        }

        /// <summary>
        /// Adds an element at the beginning of the collection
        /// </summary>
        /// <param name="element"></param>
        public void AddFirst(int element)
        {
            var newItem = new LinkedListItem(element);
            if (this.first == null)
            {
                this.first = newItem;
                this.last = newItem;
            }
            else
            {
                newItem.Next = this.first;
                this.first.Previous = newItem;
                this.first = newItem;
            }
        }

        /// <summary>
        /// adds an element at the end of the collection
        /// </summary>
        /// <param name="element"></param>
        public void AddLast(int element)
        {
            var newItem = new LinkedListItem(element);
            if (this.last == null)
            {
                this.first = newItem;
                this.last = newItem;
            }
            else
            {
                this.last.Next = newItem;
                newItem.Previous = this.last;
                this.last = newItem;
            }
        }

        /// <summary>
        /// removes the element at the beginning of the collection
        /// </summary>
        /// <returns></returns>
        public int RemoveFirst()
        {
            if (this.first == null)
            {
                throw new Exception();
            }
            else if (this.first == this.last)
            {
                var element = this.first.Value;
                this.first = null;
                this.last = null;
                return element;
            }
            else
            {
                var element = this.first.Value;
                this.first = this.first.Next;
                this.first.Previous = null;
                return element;
            }
        }

        /// <summary>
        /// removes the element at the end of the collection
        /// </summary>
        /// <returns></returns>
        public int RemoveLast()
        {
            if (this.last == null)
            {
                throw new Exception();
            }
            else if (this.first == this.last)
            {
                var element = this.last.Value;
                this.first = null;
                this.last = null;
                return element;
            }
            else
            {
                var element = this.last.Value;
                this.last = this.last.Previous;
                this.last.Next = null;
                return element;
            }
        }

        /// <summary>
        /// goes through the collection and executes a given action
        /// </summary>
        public void ForEach(Action<int> action)
        {
            LinkedListItem current = this.first;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        /// <summary>
        /// goes through the collection and executes a given func
        /// </summary>
        public void ForEach(Func<int, int> func)
        {
            LinkedListItem current = this.first;
            while (current != null)
            {
                current.Value = func(current.Value);
                current = current.Next;
            }
        }

        /// <summary>
        /// returns the collection as an array
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            int[] elements = new int[this.Count];
            LinkedListItem current = this.first;
            int index = 0;
            while (current != null)
            {
                elements[index] = current.Value;
                current = current.Next;
                index++;
            }

            return elements;
        }
    }
}