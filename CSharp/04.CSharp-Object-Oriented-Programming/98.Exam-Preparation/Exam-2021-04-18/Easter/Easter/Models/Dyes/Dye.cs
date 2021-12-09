﻿using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                this.power = value;
                if (this.power < 0)
                {
                    this.power = 0;
                }
            }
        }

        public bool IsFinished() => this.Power == 0;

        public void Use()
        {
            this.Power -= 10;
        }
    }
}
