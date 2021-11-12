namespace WildFarm.Factories
{
    using System;
    using WildFarm.Models.Animals;
    using WildFarm.Models.Animals.Birds;
    using WildFarm.Models.Animals.Mammals;
    using WildFarm.Models.Animals.Mammals.Felines;

    public class AnimalCreatorFactory : AnimalCreator
    {
        public override Animal Create(string type, string[] data)
        {
            Animal animal = null;
            animal = type switch
            {
                "Owl" => new Owl(data[1], double.Parse(data[2]), double.Parse(data[3])),
                "Hen" => new Hen(data[1], double.Parse(data[2]), double.Parse(data[3])),
                "Mouse" => new Mouse(data[1], double.Parse(data[2]), data[3]),
                "Dog" => new Dog(data[1], double.Parse(data[2]), data[3]),
                "Cat" => new Cat(data[1], double.Parse(data[2]), data[3], data[4]),
                "Tiger" => new Tiger(data[1], double.Parse(data[2]), data[3], data[4]),
                _ => throw new ArgumentException("Invalid animal type"),
            };
            return animal;
        }
    }
}
