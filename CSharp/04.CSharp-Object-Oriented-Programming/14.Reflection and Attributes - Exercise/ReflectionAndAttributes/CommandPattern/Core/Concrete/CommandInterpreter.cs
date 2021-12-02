namespace CommandPattern.Core.Concrete
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split();
            string command = cmdArgs[0];
            Type type = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name.Contains(command)).FirstOrDefault();
            ICommand executable = (ICommand)Activator.CreateInstance(type);
            return executable.Execute(cmdArgs.Skip(1).ToArray());
        }
    }
}