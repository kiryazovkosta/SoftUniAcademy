namespace CustomDoublyLinkedList
{
    public class LinkedListItem
    {
        public LinkedListItem(int value)
        {
            this.Value = value;
        }

        public LinkedListItem Previous { get; set; }
        public LinkedListItem Next { get; set; }
        public int Value { get; set; }
    }
}