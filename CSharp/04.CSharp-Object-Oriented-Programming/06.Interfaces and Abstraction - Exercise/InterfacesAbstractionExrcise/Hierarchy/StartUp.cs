namespace Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection<string>();
            var addCollectionIndexes = new List<int>();

            var addRemoveCollection = new AddRemoveCollection<string>();
            var addRemoveCollectionIndexes = new List<int>();

            var myList = new MyList<string>();
            var myListIndexes = new List<int>();

            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                addCollectionIndexes.Add(addCollection.Add(word));
                addRemoveCollectionIndexes.Add(addRemoveCollection.Add(word));
                myListIndexes.Add(myList.Add(word));
            }

            Console.WriteLine(string.Join(" ", addCollectionIndexes));
            Console.WriteLine(string.Join(" ", addRemoveCollectionIndexes));
            Console.WriteLine(string.Join(" ", myListIndexes));

            int removeCount = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < removeCount; i++)
            {
                sb.Append($"{addRemoveCollection.Remove()} ");
            }

            Console.WriteLine(sb.ToString().Trim());

            sb.Clear();
            for (int i = 0; i < removeCount; i++)
            {
                sb.Append($"{myList.Remove()} ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
