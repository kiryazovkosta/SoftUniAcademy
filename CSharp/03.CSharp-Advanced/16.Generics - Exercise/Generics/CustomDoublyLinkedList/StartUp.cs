namespace CustomDoublyLinkedList
{
    using System;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddFirst(3);
            // 3
            list.AddFirst(2);
            // 2 3
            list.AddFirst(1);
            // 1 2 3
            list.AddLast(4);
            // 1 2 3 4
            list.AddFirst(0);
            // 0 1 2 3 4
            list.AddLast(100);
            // 0 1 2 3 4 100
            list.RemoveFirst();
            // 1 2 3 4 100
            list.RemoveLast();
            // 1 2 3 4
            list.AddLast(5);
            // 1 2 3 4 5
            Console.WriteLine(string.Join("-", list.ToArray()));
            // 1-2-3-4-5
            list.ForEach(Console.WriteLine);
        }
    }
}
