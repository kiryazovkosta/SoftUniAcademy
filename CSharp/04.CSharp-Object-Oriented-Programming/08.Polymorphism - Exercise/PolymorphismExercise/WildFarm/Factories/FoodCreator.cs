namespace WildFarm.Factories
{
    using WildFarm.Models.Foods;

    public abstract class FoodCreator
    {
        public abstract Food Create(int quantity, string type);
    }
}
