namespace LineNumbers
{
    using System.IO;
    using System.Text;

    internal class Numbers
    {
        private static void Main(string[] args)
        {
            string input = "Input.txt";
            string output = "Output.txt";

            using var reader = new StreamReader(input, Encoding.UTF8);
            using var writer = new StreamWriter(output, false, Encoding.UTF8);
            string line = null;
            int counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine($"{++counter}. {line}");
            }
        }
    }
}