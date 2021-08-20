namespace Articles
{
    #region Using

    using System;

    #endregion

    public class ArticleClass
    {
        private static void Main(string[] args)
        {
            string[] articleData = Console.ReadLine().Split(", ");
            Article article = new Article(articleData[0], articleData[1], articleData[2]);

            int operationsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < operationsNumber; i++)
            {
                string[] operation = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
                string command = operation[0];
                string value = operation[1].Trim();
                switch (command)
                {
                    case "Edit":
                        article.Content = value;
                        break;

                    case "ChangeAuthor":
                        article.Author = value;
                        break;

                    case "Rename":
                        article.Title = value;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(article.ToString());
        }
    }

    public class Article
    {
        private string title;
        private string content;
        private string author;

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get => this.title; set => this.title = value; }
        public string Content { get => this.content; set => this.content = value; }
        public string Author { get => this.author; set => this.author = value; }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}