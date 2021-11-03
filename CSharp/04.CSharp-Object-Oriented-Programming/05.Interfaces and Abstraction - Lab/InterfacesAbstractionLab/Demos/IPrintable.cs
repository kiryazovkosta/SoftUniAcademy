using System;
using System.Collections.Generic;
using System.Text;

namespace Demos
{
    public interface IPrintable
    {
        void Print()
        {
            Console.WriteLine("Default behavior of Print");
        }
    }
}
