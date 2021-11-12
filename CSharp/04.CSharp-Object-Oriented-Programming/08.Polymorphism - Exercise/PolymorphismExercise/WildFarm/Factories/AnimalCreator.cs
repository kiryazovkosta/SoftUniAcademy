using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public abstract class AnimalCreator
    {
        public abstract Animal Create(string type, string[] data);
    }
}
