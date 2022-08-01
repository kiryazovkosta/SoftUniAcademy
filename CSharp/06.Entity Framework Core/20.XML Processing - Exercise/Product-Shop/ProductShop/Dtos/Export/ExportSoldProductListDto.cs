﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("products")]
    public class ExportSoldProductListDto
    {
        [XmlElement("Product")]
        public ExportSoldProductDto[] Products { get; set; }
    }
}
