using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public Engine Engine
        {
            get => this.engine;
            set => this.engine = value;
        }

        public Cargo Cargo
        {
            get => this.cargo;
            set => this.cargo = value;
        }

        public Tire[] Tires
        {
            get => this.tires;
            set
            {
                if (value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Tires));
                }

                this.tires = value;
            }
        }
    }
}
