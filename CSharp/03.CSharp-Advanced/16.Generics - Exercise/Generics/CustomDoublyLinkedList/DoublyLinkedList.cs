using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head = null;
        private ListNode<T> tail = null;

        public int Count { get; private set; }

        /// <summary>
        /// Adds an element at the beginning of the collection
        /// </summary>
        /// <param name="element"></param>
        public void AddFirst(T element)
        {
            var newItem = new ListNode<T>(element);
            if (this.Count == 0)
            {
                this.head = newItem;
                this.tail = newItem;
            }
            else
            {
                newItem.NextNode = this.head;
                this.head.PreviousNode = newItem;
                this.head = newItem;
            }

            this.Count++;
        }

        /// <summary>
        /// adds an element at the end of the collection
        /// </summary>
        /// <param name="element"></param>
        public void AddLast(T element)
        {
            var newItem = new ListNode<T>(element);
            if (this.Count == 0)
            {
                this.head = newItem;
                this.tail = newItem;
            }
            else
            {
                this.tail.NextNode = newItem;
                newItem.PreviousNode = this.tail;
                this.tail = newItem;
            }

            this.Count++;
        }

        /// <summary>
        /// removes the element at the beginning of the collection
        /// </summary>
        /// <returns></returns>
        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (this.head == this.tail)
            {
                var element = this.head.Value;
                this.head = null;
                this.tail = null;
                return element;
            }
            else
            {
                var element = this.head.Value;
                this.head = this.head.NextNode;
                this.head.PreviousNode = null;
                return element;
            }

            this.Count--;
        }

        /// <summary>
        /// removes the element at the end of the collection
        /// </summary>
        /// <returns></returns>
        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            if (this.head == this.tail)
            {
                var element = this.tail.Value;
                this.head = null;
                this.tail = null;
                return element;
            }
            else
            {
                var element = this.tail.Value;
                this.tail = this.tail.PreviousNode;
                this.tail.NextNode = null;
                return element;
            }

            this.Count--;
        }

        /// <summary>
        /// goes through the collection and executes a given action
        /// </summary>
        public void ForEach(Action<T> action)
        {
            ListNode<T> current = this.head;
            while (current != null)
            {
                action(current.Value);
                current = current.NextNode;
            }
        }

        /// <summary>
        /// returns the collection as an array
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] elements = new T[this.Count];
            ListNode<T> current = this.head;
            int index = 0;
            while (current != null)
            {
                elements[index] = current.Value;
                current = current.NextNode;
                index++;
            }

            return elements;
        }
    }
}