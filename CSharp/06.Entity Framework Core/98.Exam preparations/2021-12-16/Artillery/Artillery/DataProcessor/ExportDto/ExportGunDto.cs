using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artillery.DataProcessor.ExportDto
{
    public class ExportGunDto
    {
        public string GunType { get; set; }

        public int GunWeight { get; set; }

        public double BarrelLength { get; set; }

        public string Range { get; set; }
    }
}
