using System;

namespace Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
            string[] elements = new string[data.Length - 1];
            Array.Copy(data, 1, elements, 0, elements.Length);
            ListyIterator<string> list = new ListyIterator<string>(elements);

            string input = Console.ReadLine();
            while (input != "END")
            {
                try
                {

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                switch (input)
                {
                    case "Move":
                        var result = list.Move();
                        Console.WriteLine(result);
                        break;

                    case "HasNext":
                        result = list.HasNext();
                        Console.WriteLine(result);
                        break;

                    case "Print":
                        try
                        {
                            var element = list.Print();
                            Console.WriteLine(element);
                        }
                        catch (InvalidOperationException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;

                    case "PrintAll":
                        var output = list.PrintAll();
                        Console.WriteLine(output);
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
