namespace CustomDoublyLinkedList
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public ListNode<T> NextNode { get; set; }
        public ListNode<T> PreviousNode { get; set; }

        public T Value { get; set; }
    }
}