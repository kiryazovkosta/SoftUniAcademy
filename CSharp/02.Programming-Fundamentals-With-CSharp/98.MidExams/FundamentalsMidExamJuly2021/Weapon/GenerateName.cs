namespace Weapon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GenerateName
    {
        static void Main(string[] args)
        {
            List<string> name = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] operation = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = operation[0];
                switch (command)
                {
                    case "Add":
                        string particle = operation[1];
                        int index = int.Parse(operation[2]);
                        if (index >= 0 && index < name.Count )
                        {
                            name.Insert(index, particle);
                        }
                        break;

                    case "Remove":
                        index = int.Parse(operation[1]);
                        if (index >= 0 && index < name.Count)
                        {
                            name.RemoveAt(index);
                        }
                        break;

                    case "Check":
                        string type = operation[1];
                        if (type == "Even")
                        {
                            var even = new List<string>();
                            for (int i = 0; i < name.Count; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    even.Add(name[i]);
                                }
                            }

                            Console.WriteLine(string.Join(" ", even));
                        }
                        else if (type == "Odd")
                        {
                            var odd = new List<string>();
                            for (int i = 0; i < name.Count; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    odd.Add(name[i]);
                                }
                            }

                            Console.WriteLine(string.Join(" ", odd));
                        }

                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You crafted {string.Join("", name)}!");
        }
    }
}
