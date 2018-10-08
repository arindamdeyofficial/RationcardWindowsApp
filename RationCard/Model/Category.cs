using RationCard.Interface;
using System;
using System.Xml.Serialization;

namespace RationCard.Model
{
    [Serializable]
    public class Category: ICategory
    {
        [XmlAttribute]
        public string Cat_Id { get; set; }
        [XmlAttribute]
        public string Cat_Key { get; set; }
        [XmlAttribute]
        public string Cat_Desc { get; set; }
        [XmlAttribute]
        public string CardCount { get; set; }
        [XmlAttribute]
        public string FamilyCount { get; set; }
    }
}
