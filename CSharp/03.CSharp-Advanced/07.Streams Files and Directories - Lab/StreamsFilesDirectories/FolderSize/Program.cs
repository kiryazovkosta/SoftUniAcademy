using System;
using System.IO;
using System.Text;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = @"F:\temp\04. CSharp-Advanced-Streams-Files-and-Directories-Lab-Resources\Resources\06. Folder Size\TestFolder";
            long size = GetSize(folder);
            using StreamWriter writer = new StreamWriter("Output.txt", false, Encoding.UTF8);
            writer.WriteLine(BitesToMegabytes(size));
        }

        private static decimal BitesToMegabytes(long size)
        {
            return size * 0.000001M;
        }

        private static long GetSize(string folder)
        {
            long size = 0;

            string[] files = Directory.GetFiles(folder);
            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                size += fi.Length;
            }

            string[] directories = Directory.GetDirectories(folder);
            foreach (var directory in directories)
            {
                size += GetSize(directory);
            }

            return size;
        }
    }
}
