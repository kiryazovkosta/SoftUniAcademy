using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artillery.DataProcessor.ExportDto
{
    public class ExportShellDto
    {
        public double ShellWeight { get; set; }

        public string Caliber { get; set; }

        public ExportGunDto[] Guns { get; set; }
    }
}
