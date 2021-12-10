namespace AquaShop.Models.Fish
{
    using System;

    public class FreshwaterFish : Fish
    {
        private const int FreshwaterFishInitialSize = 3;
        private const int FreshwaterFishIncreaseSize = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = FreshwaterFishInitialSize;
        }

        public override void Eat()
        {
            this.Size += FreshwaterFishIncreaseSize;
        }
    }
}
