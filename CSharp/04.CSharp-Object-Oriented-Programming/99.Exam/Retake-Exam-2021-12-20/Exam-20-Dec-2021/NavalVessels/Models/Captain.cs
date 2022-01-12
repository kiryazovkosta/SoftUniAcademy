using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        public Captain(string fullName)
        {

        }

        public string FullName => throw new NotImplementedException();

        public int CombatExperience => throw new NotImplementedException();

        public ICollection<IVessel> Vessels => throw new NotImplementedException();

        public void AddVessel(IVessel vessel)
        {
            throw new NotImplementedException();
        }

        public void IncreaseCombatExperience()
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
