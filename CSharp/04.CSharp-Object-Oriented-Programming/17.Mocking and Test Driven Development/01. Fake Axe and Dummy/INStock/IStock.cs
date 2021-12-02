namespace INStock
{
    using System.Collections.Generic;

    public interface IStock : IEnumerable<Product>
    {
        //Properties
        int Count { get; }

        //Validations
        bool Contains(Product product);

        //Modifications
        void Add(Product product);
        void ChangeQuantity(string product, int quantity);

        //Retrievals
        Product Find(int index);
        Product FindByLabel(string label);
        IEnumerable<Product> FindFirstByAlphabeticalOrder(int count);


        //Querying
        IEnumerable<Product> FindAllInRange(decimal lo, decimal hi);
        IEnumerable<Product> FindAllByPrice(decimal price);
        IEnumerable<Product> FindFirstMostExpensiveProducts(int count);
        IEnumerable<Product> FindAllByQuantity(int quantity);
    }
}