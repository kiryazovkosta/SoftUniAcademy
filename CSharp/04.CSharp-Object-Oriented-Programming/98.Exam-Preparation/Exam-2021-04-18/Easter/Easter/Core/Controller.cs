using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private IRepository<IBunny> bunnies; 
        private IRepository<IEgg> eggs;
        private IWorkshop workshop;
        private int countColoredEggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
            countColoredEggs = 0;
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            switch (bunnyType)
            {
                case nameof(HappyBunny):
                    this.bunnies.Add(new HappyBunny(bunnyName));
                    break;

                case nameof(SleepyBunny):
                    this.bunnies.Add(new SleepyBunny(bunnyName));
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            bunny.Dyes.Add(dye);
            return $"Successfully added dye with power {dye.Power} to bunny {bunny.Name}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggs.Add(egg);
            return $"Successfully added egg: {egg.Name}!";
        }

        public string ColorEgg(string eggName)
        {
            var suitableBunnies = this.bunnies.Models.Where(b => b.Energy >= 50).OrderByDescending(b => b.Energy).ToList();
            if (!suitableBunnies.Any())
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            IEgg egg = this.eggs.FindByName(eggName);

            foreach (IBunny bunny in suitableBunnies)
            {
                this.workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    this.countColoredEggs++;
                    break;
                }
            }

            return egg.IsDone() ? $"Egg {egg.Name} is done" : $"Egg {egg.Name} is not done.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{countColoredEggs} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (IBunny bunny in this.bunnies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"{bunny.Dyes.Where(d => !d.IsFinished()).Count()} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
