﻿using System;
using System.Xml.Serialization;

namespace RationCard.Model
{
    [Serializable]
    public class ProductClassMaster
    {
        [XmlAttribute]
        public string ProductClassMasterId { get; set; }
        [XmlAttribute]
        public string ProductDeptMasterId { get; set; }
        [XmlAttribute]
        public string ProductSubDeptMasterId { get; set; }
        [XmlAttribute]
        public string ProductClassMasterDesc { get; set; }
    }
}
