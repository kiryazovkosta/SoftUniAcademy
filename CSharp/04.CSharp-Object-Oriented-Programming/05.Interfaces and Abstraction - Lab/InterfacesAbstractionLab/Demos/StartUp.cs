using System;
using System.Collections.Generic;

namespace Demos
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IPrintable> documents = new List<IPrintable>();
            documents.Add(new Document());
            documents.Add(new PdfDocument());
            documents.Add(new WebPage());
            documents.Add(new PdfDocument());
            documents.Add(new Document());
            documents.Add(new Document());
            foreach (var doc in documents)
            {
                doc.Print();
                //Do(doc);
            }
        }

        static void Do(IPrintable p)
        {
            p.Print();
        }
    }
}
