using System;
using System.Xml.Serialization;

namespace RationCard.Model
{
    [Serializable]
    public class ProductSubClassMaster
    {
        [XmlAttribute]
        public string ProductSubClassMasterId { get; set; }
        [XmlAttribute]
        public string ProductClassMasterId { get; set; }
        [XmlAttribute]
        public string ProductDeptMasterId { get; set; }
        [XmlAttribute]
        public string ProductSubDeptMasterId { get; set; }
        [XmlAttribute]
        public string ProductSubClassMasterDesc { get; set; }
    }
}
