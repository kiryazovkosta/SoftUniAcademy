namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        private readonly Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString()
        {
            int index = this.random.Next(0, base.Count - 1);
            return base[index];
        }
    }
}