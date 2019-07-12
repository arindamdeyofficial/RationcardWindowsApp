using RationCard.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RationCard.Model
{
    [Serializable]
    public class BillDetails
    {
        [XmlAttribute]
        public string Bill_Id_Identity { get; set; }
        [XmlElement]
        public Category CardCategory { get; set; }
        [XmlAttribute]
        public int NumberOfCards { get; set; }
        [XmlAttribute]
        public string CardNumbers { get; set; }

        [XmlElement]
        public Product ProductsSold { get; set; }
    }
}
