using System.Xml.Serialization;

namespace RationCard.Model
{
    public class ProductDeptMaster
    {
        [XmlAttribute]
        public string ProductDeptMasterId { get; set; }
        [XmlAttribute]
        public string ProductDeptMasterDesc { get; set; }
    }
}
