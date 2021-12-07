using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Racer Repository");
            }

            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return this.models.FirstOrDefault(r => r.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }
    }
}
