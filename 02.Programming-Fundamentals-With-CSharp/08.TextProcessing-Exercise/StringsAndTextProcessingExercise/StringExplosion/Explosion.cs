namespace StringExplosion
{
    using System;
    public class Explosion
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int strength = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                if (symbol == '>')
                {
                    strength += int.Parse(text[i + 1].ToString());
                }
                else if (strength > 0 )
                {
                    text = text.Remove(i, 1);
                    strength--;
                    i--;
                }
            }

            Console.WriteLine(text);
        }
    }
}