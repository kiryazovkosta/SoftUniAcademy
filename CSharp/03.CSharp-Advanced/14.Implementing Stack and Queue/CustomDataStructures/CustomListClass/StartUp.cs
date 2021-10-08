namespace CustomListClass
{
    using System;
    using System.Diagnostics;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new CustomList();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            Debug.Assert(list[2] == 2);
            Debug.Assert(list.Count == 10);

            list.RemoveAt(2);
            Debug.Assert(list[2] == 3);
            Debug.Assert(list.Count == 9);
        }
    }
}
