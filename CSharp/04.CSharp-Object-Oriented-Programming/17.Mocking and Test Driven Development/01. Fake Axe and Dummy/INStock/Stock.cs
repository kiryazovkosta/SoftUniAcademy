using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class Stock : IStock
    {
        private int index = 0;
        private IDictionary<string, Product> byLabel;
        private IDictionary<int, Product> byIndex;
        private IDictionary<int, HashSet<Product>> byQuantity;
        private SortedSet<string> sortedLabels;

        public Stock()
        {
            byLabel = new Dictionary<string, Product>();
            byIndex = new Dictionary<int, Product>();
            byQuantity = new Dictionary<int, HashSet<Product>>();
            sortedLabels = new SortedSet<string>();
        }


        public int Count { get; set; }

        public void Add(Product product)
        {
            this.Count++;
            this.byLabel[product.Label] = product;
            this.byIndex[index++] = product;

            if (!this.byQuantity.ContainsKey(product.Quantity))
            {
                this.byQuantity[product.Quantity] = new HashSet<Product>();
            }

            this.byQuantity[product.Quantity].Add(product);
            this.sortedLabels.Add(product.Label);
        }

        public void ChangeQuantity(string product, int quantity)
        {
            if (!byLabel.ContainsKey(product))
            {
                throw new ArgumentException();
            }

            var productt = byLabel[product];
            this.byQuantity[productt.Quantity].Remove(productt);

            if (!this.byQuantity.ContainsKey(quantity))
            {
                this.byQuantity[quantity] = new HashSet<Product>();
            }
            productt.Quantity = quantity;

            this.byQuantity[quantity].Add(productt);
        }

        public bool Contains(Product product)
        {
            return this.byLabel.ContainsKey(product.Label);
        }

        public Product Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return this.byIndex[index];
        }

        public IEnumerable<Product> FindAllByPrice(decimal price)
        {
            return this.byIndex.Values.Where(p => p.Price == price);
        }

        public IEnumerable<Product> FindAllByQuantity(int quantity)
        {
            if (!this.byQuantity.ContainsKey(quantity) || this.byQuantity[quantity].Count == 0)
            {
                return Enumerable.Empty<Product>();
            }

            return this.byQuantity[quantity];
        }

        public IEnumerable<Product> FindAllInRange(decimal lo, decimal hi)
        {
            return this.byIndex.Values.Where(p => p.Price > lo && p.Price <= hi)
              .OrderByDescending(p => p);
        }

        public Product FindByLabel(string label)
        {
            if (byLabel.ContainsKey(label))
            {
                return byLabel[label];
            }

            throw new ArgumentException();
        }

        public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
        {
            if (count > this.Count || count < 0)
            {
                throw new ArgumentException();
            }

            return this.sortedLabels.Take(count).Select(l => byLabel[l]);
        }

        public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
        {
            if (count > this.Count || count < 0)
            {
                throw new ArgumentException();
            }

            return this.byIndex.Values.OrderByDescending(p => p.Price).Take(count);
        }

        public IEnumerator<Product> GetEnumerator()
        {
            foreach (var product in this.byIndex.Values)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
