namespace ActivationKeys
{
    #region Using

    using System;
    using System.Text;

    #endregion

    internal class Activation
    {
        private static void Main(string[] args)
        {
            var password = Console.ReadLine();

            var input = Console.ReadLine();
            while (input != "Generate")
            {
                var data = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                var command = data[0].Trim();
                if (command == "Contains")
                {
                    var substring = data[1].Trim();
                    Console.WriteLine(password.Contains(substring)
                        ? $"{password} contains {substring}"
                        : "Substring not found!");
                }
                else if (command == "Flip")
                {
                    var type = data[1].Trim();
                    var startIndex = int.Parse(data[2].Trim());
                    var endIndex = int.Parse(data[3].Trim());
                    var result = new StringBuilder();
                    for (var i = 0; i < password.Length; i++)
                    {
                        var symbol = password[i];
                        if (i >= startIndex && i < endIndex)
                        {
                            if (type == "Upper")
                            {
                                symbol = char.ToUpper(symbol);
                            }
                            else
                            {
                                symbol = char.ToLower(symbol);
                            }
                        }

                        result.Append(symbol);
                    }

                    password = result.ToString();
                    Console.WriteLine(password);
                }
                else if (command == "Slice")
                {
                    var startIndex = int.Parse(data[1].Trim());
                    var endIndex = int.Parse(data[2].Trim());

                    for (var i = endIndex - 1; i >= startIndex; i--)
                    {
                        password = password.Remove(i, 1);
                    }

                    Console.WriteLine(password);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {password}");
        }
    }
}