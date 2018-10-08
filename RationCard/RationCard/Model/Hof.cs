using RationCard.Interface;

namespace RationCard.Model
{
    public class Hof: Customer
    {
        public int TotalCardCount { get; set; }
        public int TotalActiveCardCount { get; set; }
        public string CardNo { get; set; }
        public string ShowVal { get; set; }
    }
}
