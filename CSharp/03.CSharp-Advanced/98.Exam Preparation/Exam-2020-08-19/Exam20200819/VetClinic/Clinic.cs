using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (this.Capacity > data.Count)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name);
            return data.Remove(pet);
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = data.OrderByDescending(p => p.Age).FirstOrDefault();
            return pet;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().Trim();
        }
    }
}
