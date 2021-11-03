namespace Demos
{
    using System;
    class WebPage : IPrintable
    {
        public void Print()
        {
            Console.WriteLine($"Implemented behavior in class {this.GetType().Name}");
        }
    }
}
