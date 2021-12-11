using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            switch (gymType)
            {
                case nameof(BoxingGym):
                    this.gyms.Add(new BoxingGym(gymName));
                    break;

                case nameof(WeightliftingGym):
                    this.gyms.Add(new WeightliftingGym(gymName));
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            switch (equipmentType)
            {
                case nameof(BoxingGloves):
                    this.equipment.Add(new BoxingGloves());
                    break;
                case nameof(Kettlebell):
                    this.equipment.Add(new Kettlebell());
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equip = this.equipment.FindByType(equipmentType);
            if (equip == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            gym.AddEquipment(equip);
            this.equipment.Remove(equip);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gym.Name);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            switch (athleteType)
            {
                case nameof(Boxer):
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;

                case nameof(Weightlifter):
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym gym = this.gyms.First(g => g.Name == gymName);

            if (athlete.GetType().Name == nameof(Boxer) && gym.GetType().Name == nameof(BoxingGym))
            {
                gym.AddAthlete(athlete);
            }
            else if (athlete.GetType().Name == nameof(Weightlifter) && gym.GetType().Name == nameof(WeightliftingGym))
            {
                gym.AddAthlete(athlete);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.First(g => g.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }







        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.First(g => g.Name == gymName);
            double value = gym.EquipmentWeight;
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, value);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IGym gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
