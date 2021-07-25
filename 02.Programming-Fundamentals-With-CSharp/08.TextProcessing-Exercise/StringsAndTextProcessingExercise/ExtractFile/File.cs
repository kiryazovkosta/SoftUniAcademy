namespace ExtractFile
{
    using System;
    public class File
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int index = path.LastIndexOf('\\');
            string file = path.Substring(index + 1, path.Length - index - 1);
            index = file.IndexOf('.');
            string fileName = file.Substring(0, index);
            string fileExtension = file.Substring(index + 1, file.Length - index - 1);
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}