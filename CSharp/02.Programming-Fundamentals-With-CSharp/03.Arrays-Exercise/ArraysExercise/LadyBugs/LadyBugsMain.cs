namespace LadyBugs
{
    using System;
    using System.Linq;

    public class LadyBugsMain
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(size)));
            int[] field = new int[size];
            int[] indexes = Console.ReadLine()
                                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray()
                            ?? new int[] { };

            for (int i = 0; i < indexes.Length; i++)
            {
                int index = indexes[i];
                if (index >= 0 && index < field.Length)
                {
                    field[index] = 1;
                }
            }

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int bugIndex = int.Parse(command[0]);
                string direction = command[1].ToLower();
                int length = int.Parse(command[2]);


                if ((bugIndex >= 0 && bugIndex < field.Length) 
                    && field[bugIndex] == 1
                    && length != 0)
                {
                    field[bugIndex] = 0;

                    if (direction == "right")
                    {
                        long newIndex = bugIndex + length;
                        if (newIndex >= 0 && newIndex < field.Length)
                        {
                            do
                            {
                                if (field[newIndex] == 0)
                                {
                                    field[newIndex] = 1;
                                    break;
                                }
                                
                                newIndex += length ;
                            } while (newIndex < field.Length);
                        }
                    }
                    else if(direction == "left")
                    {
                        long newIndex = bugIndex - length;
                        if (newIndex >= 0 && newIndex < field.Length)
                        {
                            do
                            {
                                if (field[newIndex] == 0)
                                {
                                    field[newIndex] = 1;
                                    break;
                                }

                                newIndex -= length;
                            } while (newIndex >= 0);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
