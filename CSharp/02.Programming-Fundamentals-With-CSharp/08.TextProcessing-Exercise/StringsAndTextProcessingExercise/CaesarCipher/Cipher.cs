namespace CaesarCipher
{
    using System;
    using System.Text;

    public class Cipher
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            foreach (var symbol in text)
            {
                int value = symbol + 3;
                output.Append((char)value);
            }

            Console.WriteLine(output.ToString());
        }
    }
}