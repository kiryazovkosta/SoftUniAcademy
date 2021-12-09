using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core.Contracts
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private IMission mission;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
            exploredPlanetsCount = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            if (type == nameof(Biologist))
            {
                this.astronauts.Add(new Biologist(astronautName));
            }
            else if (type == nameof(Geodesist))
            {
                this.astronauts.Add(new Geodesist(astronautName));
            }
            else if (type == nameof(Meteorologist))
            {
                this.astronauts.Add(new Meteorologist(astronautName));
            }

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (string item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
           IAstronaut astronaut = this.astronauts.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(astronaut);
            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            var suitable = this.astronauts.Models.Where(a => a.Oxygen > 60).ToList();
            if (!suitable.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            int beforeCount = suitable.Count();

            IPlanet planet = this.planets.FindByName(planetName);
            this.mission.Explore(planet, suitable);
            this.exploredPlanetsCount++;

            int after = 0;
            foreach (var astronaut in suitable)
            {
                if (!astronaut.CanBreath)
                {
                    after++;
                }
            }

            return String.Format(OutputMessages.PlanetExplored, planetName, after);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                string items = astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none";
                sb.AppendLine($"Bag items: {items}");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
