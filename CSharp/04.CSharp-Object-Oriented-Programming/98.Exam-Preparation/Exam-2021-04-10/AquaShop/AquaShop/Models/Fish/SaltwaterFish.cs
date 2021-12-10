using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int SaltwaterFishInitialSize = 5;
        private const int SaltwaterFishIncreaseSize = 2;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = SaltwaterFishInitialSize;
        }

        public override void Eat()
        {
            this.Size += SaltwaterFishIncreaseSize;
        }
    }
}
