namespace SongsQueue
{
    using System;
    using System.Collections.Generic;

    public class Songs
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine()?.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songs = new Queue<string>();
            foreach (var song in data)
            {
                songs.Enqueue(song);
            }

            while (songs.Count > 0)
            {
                string input = Console.ReadLine();
                if (input == "Play")
                {
                    songs.Dequeue();
                }
                else if (input == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs.ToArray()));
                }
                else if (input.StartsWith("Add"))
                {
                    string[] song = input.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries);
                    string songName = song[1];
                    if (songs.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songName);
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}