namespace OddLines
{
    using System.IO;
    using System.Text;

    public class Lines
    {
        private const string input = "Input.txt";
        private const string output = "Output.txt";

        static void Main(string[] args)
        {
            if (File.Exists(output))
            {
                File.Delete(output);
            }

            using var reader = new StreamReader(input, Encoding.UTF8);
            using var writer = new StreamWriter(output, false, Encoding.UTF8);
            string line = null;
            int counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (counter % 2 != 0)
                {
                    writer.WriteLine(line);
                }

                counter++;
            }
        }
    }
}
