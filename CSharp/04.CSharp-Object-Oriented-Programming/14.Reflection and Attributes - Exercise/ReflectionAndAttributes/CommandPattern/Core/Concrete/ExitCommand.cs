using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core.Concrete
{
    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
