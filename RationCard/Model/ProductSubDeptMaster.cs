using System;
using System.Xml.Serialization;

namespace RationCard.Model
{
    [Serializable]
    public class ProductSubDeptMaster
    {
        [XmlAttribute]
        public string ProductSubDeptMasterId { get; set; }
        [XmlAttribute]
        public string ProductDeptMasterId { get; set; }
        [XmlAttribute]
        public string ProductSubDeptMasterDesc { get; set; }
    }
}
