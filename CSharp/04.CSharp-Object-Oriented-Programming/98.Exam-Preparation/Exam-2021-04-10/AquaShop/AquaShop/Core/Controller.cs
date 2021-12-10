using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            switch (aquariumType)
            {
                case nameof(FreshwaterAquarium):
                    aquariums.Add(new FreshwaterAquarium(aquariumName));
                        break;
                case nameof(SaltwaterAquarium):
                    aquariums.Add(new SaltwaterAquarium(aquariumName));
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            switch (decorationType)
            {
                case nameof(Ornament):
                    this.decorations.Add(new Ornament());
                    break;

                case nameof(Plant):
                    this.decorations.Add(new Plant());
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name.Equals(aquariumName, StringComparison.OrdinalIgnoreCase));
            
            IFish fish;
            switch (fishType)
            {
                case nameof(SaltwaterFish):
                    fish = new SaltwaterFish(fishName, fishSpecies, price); 
                    break;

                case nameof(FreshwaterFish):
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (fish.GetType().Name == nameof(SaltwaterFish) 
                && aquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                aquarium.AddFish(fish);
            }
            else if (fish.GetType().Name == nameof(FreshwaterFish)
                && aquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                aquarium.AddFish(fish);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }

            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            decimal price = aquarium.Fish.Sum(f => f.Price);
            price += aquarium.Decorations.Sum(f => f.Price);
            return String.Format(OutputMessages.AquariumValue, aquariumName, price);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAquarium aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
