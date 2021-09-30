namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"C:\Windows");
            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();
            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                string extension = fi.Extension;
                string name = fi.Name;
                long length = fi.Length;

                if (!data.ContainsKey(extension))
                {
                    data.Add(extension, new Dictionary<string, long>());
                }

                data[extension].Add(name, length);
            }

            string output = "report.txt";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFile = Path.Combine(path, output);

            using StreamWriter writer = File.CreateText(outputFile); 
            foreach (var extension in data.OrderByDescending(e => e.Value.Values.Count).ThenBy(e => e.Key))
            {
                writer.WriteLine($"{extension.Key}");
                foreach (var file in extension.Value.OrderBy(f => f.Value))
                {
                    writer.WriteLine($"{file.Key} - {file.Value * 0.001}kb");
                }
            }
        }
    }
}
