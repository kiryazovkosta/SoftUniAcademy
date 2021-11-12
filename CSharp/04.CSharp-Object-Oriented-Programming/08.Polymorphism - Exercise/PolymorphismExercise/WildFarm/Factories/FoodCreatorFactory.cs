using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    public class FoodCreatorFactory : FoodCreator
    {
        public override Food Create(int quantity, string type)
        {
            Food food = null;
            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;

                case "Fruit":
                    food = new Fruit(quantity);
                    break;

                case "Meat":
                    food = new Meat(quantity);
                    break;

                case "Seeds":
                    food = new Seeds(quantity);
                    break;

                default:
                    break;
            }
            return food;
        }
    }
}
