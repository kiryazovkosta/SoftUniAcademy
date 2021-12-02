namespace CommandPattern.Core.Concrete
{
    using CommandPattern.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreterParam)
        {
            commandInterpreter = commandInterpreterParam;
        }

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                string result = commandInterpreter.Read(command);
                if (result == null)
                {
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}