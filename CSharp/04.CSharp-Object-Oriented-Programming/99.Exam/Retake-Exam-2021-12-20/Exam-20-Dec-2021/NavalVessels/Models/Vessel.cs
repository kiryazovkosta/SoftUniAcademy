using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        public string name;
        public ICaptain captain;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                this.captain = value;
            }
        }

        public double ArmorThickness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double MainWeaponCaliber => throw new NotImplementedException();

        public double Speed => throw new NotImplementedException();

        public ICollection<string> Targets => throw new NotImplementedException();

        public void Attack(IVessel target)
        {
            throw new NotImplementedException();
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
