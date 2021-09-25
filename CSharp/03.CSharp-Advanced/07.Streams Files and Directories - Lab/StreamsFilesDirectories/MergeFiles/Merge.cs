namespace MergeFiles
{
    using System;
    using System.IO;
    using System.Text;

    class Merge
    {
        static void Main(string[] args)
        {
            using StreamReader first = new StreamReader("FileOne.txt");
            using StreamReader second = new StreamReader("FileTwo.txt");
            using StreamWriter output = new StreamWriter("Merge.txt", false, Encoding.UTF8);
            while (!first.EndOfStream || !second.EndOfStream )
            {
                string firstLine = first.ReadLine();
                if (firstLine != null)
                {
                    output.WriteLine(firstLine);
                }

                string secondLine = second.ReadLine();
                if (secondLine != null)
                {
                    output.WriteLine(secondLine);
                }
            }
        }
    }
}
