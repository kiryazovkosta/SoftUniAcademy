using System;
using System.Collections.Generic;
using System.Text;

namespace CustomListClass
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public void Add(int element)
        {
            this.Resize();
            this.items[Count] = element;
            this.Count++;

        }

        public int RemoveAt(int index)
        {
            this.ValidateIndex(index);
            int value = this.items[index];
            this.ShiftToLeft(index);
            this.Count--;
            if (this.Count * 4 < (this.items.Length))
            {
                this.Shrink();
            }
            return value;
        }

        public void Insert(int index, int element)
        {
            this.ValidateIndex(index);
            this.Count++;
            this.Resize();
            this.ShiftToRight(index);
            this.items[index] = element;
        }

        public bool Contains(int element)
        {
            bool found = false;
            foreach (var item in this.items)
            {
                if (item == element)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);
            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        private void Resize()
        {
            if (this.items.Length == this.Count)
            {
                int size = this.items.Length;
                int[] newArray = new int[size * 2];
                Array.Copy(this.items, 0, newArray, 0, this.items.Length);
                this.items = newArray;
            }
        }

        private void Shrink()
        {
            if (this.Count * 4 < (this.items.Length))
            {
                int size = this.items.Length;
                int[] newArray = new int[size / 2];
                Array.Copy(this.items, newArray, newArray.Length);
                this.items = newArray;
            }
        }

        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
        }

        public void ShiftToRight(int index)
        {
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}
