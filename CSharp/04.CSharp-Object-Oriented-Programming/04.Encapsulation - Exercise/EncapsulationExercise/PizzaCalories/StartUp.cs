namespace PizzaCalories
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaData = Console.ReadLine().Split(" ");
                string pizzaName = pizzaData[1];

                string input = Console.ReadLine();
                string[] data = input.Split(" ");
                Dough dough = new Dough(data[1], data[2], int.Parse(data[3]));
                Pizza pizza = new Pizza(pizzaName, dough);

                input = Console.ReadLine();
                while (input != "END")
                {
                    data = input.Split(" ");
                    Topping topping = new Topping(data[1], int.Parse(data[2]));
                    pizza.AddTopping(topping);
                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories():F2} Calories.");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
