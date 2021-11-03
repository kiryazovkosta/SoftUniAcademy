namespace Demos
{
    using System;
    class PdfDocument : IPrintable
    {
        public void Print()
        {
            Console.WriteLine($"Implemented behavior in class {this.GetType().Name}");
        }
    }
}
