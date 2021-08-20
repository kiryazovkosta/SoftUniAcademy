namespace Html
{
    using System;
    using System.Text;
    public class CreatePage
    {
        static void Main(string[] args)
        {
            string tab = "    ";
            StringBuilder html = new StringBuilder();
            string title = Console.ReadLine();
            html.AppendLine("<h1>");
            html.AppendLine($"{tab}{title}");
            html.AppendLine("</h1>");

            string content = Console.ReadLine();
            html.AppendLine("<article>");
            html.AppendLine($"{tab}{content}");
            html.AppendLine("</article>");

            string input = Console.ReadLine();
            while (input != "end of comments")
            {
                html.AppendLine("<div>");
                html.AppendLine($"{tab}{input}");
                html.AppendLine("</div>");
                input = Console.ReadLine();
            }

            Console.WriteLine(html.ToString());
        }
    }
}