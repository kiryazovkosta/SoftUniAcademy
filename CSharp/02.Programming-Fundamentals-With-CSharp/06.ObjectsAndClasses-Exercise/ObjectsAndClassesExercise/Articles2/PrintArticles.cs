namespace Articles2
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class PrintArticles
    {
        private static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] articleData = Console.ReadLine().Split(", ");
                Article article = new Article(articleData[0], articleData[1], articleData[2]);
                articles.Add(article);
            }

            string sort = Console.ReadLine();
            if (sort == "title")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articles.OrderBy(a => a.Title)));
            }
            else if (sort == "content")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articles.OrderBy(a => a.Content)));
            }
            else if (sort == "author")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articles.OrderBy(a => a.Author)));
            }
        }
    }

    public class Article
    {
        private string author;
        private string content;
        private string title;

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title
        {
            get => this.title;
            set => this.title = value;
        }

        public string Content
        {
            get => this.content;
            set => this.content = value;
        }

        public string Author
        {
            get => this.author;
            set => this.author = value;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}