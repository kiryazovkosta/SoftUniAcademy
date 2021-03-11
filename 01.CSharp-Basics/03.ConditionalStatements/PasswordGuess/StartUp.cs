namespace PasswordGuess
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            if (password.Equals("s3cr3t!P@ssw0rd"))
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
