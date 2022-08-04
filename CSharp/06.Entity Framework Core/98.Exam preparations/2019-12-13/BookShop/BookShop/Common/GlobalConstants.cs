namespace BookShop.Common
{
    public static class GlobalConstants
    {
        // Author
        public const int AuthorFirstNameMaxLength = 30;
        public const int AuthorFirstNameMinLength = 3;
        public const int AuthorLastNameMaxLength = 30;
        public const int AuthorLastNameMinLength = 3;

        // Book
        public const int BookNameMaxLength = 30;
        public const int BookNameMinLength = 3;

        public const decimal BookPriceMinValue = 0.01m;
        public const decimal BookPriceMaxValue = decimal.MaxValue;

        public const int BookPageMinValue = 50;
        public const int BookPageMaxValue = 5000;

        public const string BookReleasedOnFormat = @"MM/dd/yyyy";
    }
}
