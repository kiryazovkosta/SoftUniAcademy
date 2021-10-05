namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var trainers = ReadTrainersFromConsole();
            MakeTournament(trainers);
            PrintTrainersToConsole(trainers);
        }

        private static void PrintTrainersToConsole(List<Trainer> trainers)
        {
            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        private static void MakeTournament(List<Trainer> trainers)
        {
            string command = Console.ReadLine() ?? string.Empty;
            while (command != "End")
            {
                ElementType element = (ElementType) Enum.Parse(typeof(ElementType), command);
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.IncreaseBadges();
                    }
                    else
                    {
                        trainer.DecreasePokemonsHealth();
                        trainer.RemoveDeathPokemons();
                    }
                }

                command = Console.ReadLine();
            }
        }

        private static List<Trainer> ReadTrainersFromConsole()
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine() ?? string.Empty;
            while (input != "Tournament")
            {
                string[] data = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                ElementType pokemonElementType = ElementType.Undefined;
                if (Enum.IsDefined(typeof(ElementType), pokemonElement))
                {
                    pokemonElementType = (ElementType) Enum.Parse(typeof(ElementType), pokemonElement);
                }

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElementType, pokemonHealth);

                Trainer trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(pokemon);
                }

                input = Console.ReadLine();
            }

            return trainers;
        }
    }
}
