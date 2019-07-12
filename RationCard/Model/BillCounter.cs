using RationCard.Interface;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RationCard.Model
{
    [Serializable]
    public class BillCounter
    {
        [XmlAttribute]
        public string Bill_Counter_Identity { get; set; }
        [XmlAttribute]
        public string Dist_Id { get; set; }
        [XmlAttribute]
        public string TotalBillCOunter { get; set; }
        [XmlAttribute]
        public string DailyBillCOunterOrCount { get; set; }
        [XmlAttribute]
        public string BillDate { get; set; }
    }
}
