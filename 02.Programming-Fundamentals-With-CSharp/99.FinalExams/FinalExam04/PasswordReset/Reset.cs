namespace PasswordReset
{
    #region Using

    using System;
    using System.Text;

    #endregion

    internal class Reset
    {
        private static void Main(string[] args)
        {
            var password = Console.ReadLine();

            var input = Console.ReadLine();
            while (input != "Done")
            {
                var data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (data[0])
                {
                    case "TakeOdd":
                        var result = new StringBuilder();
                        for (var i = 1; i < password.Length; i += 2)
                        {
                            result.Append(password[i]);
                        }

                        password = result.ToString();
                        Console.WriteLine(password);
                        break;

                    case "Cut":
                        var index = int.Parse(data[1]);
                        var length = int.Parse(data[2]);
                        password = password.Remove(index, length);
                        Console.WriteLine(password);
                        break;

                    case "Substitute":
                        var substring = data[1];
                        var substitute = data[2];
                        if (password.IndexOf(substring) >= 0)
                        {
                            password = password.Replace(substring, substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }

                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}