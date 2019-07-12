namespace RationCard.Model
{
    public class Product: ProductMaster
    {
        public string UnitOfMeasure { get; set; }
        public bool IsDefaultProduct { get; set; }
        public bool IsDefaultGiveRation { get; set; }
        public string BaseUom { get; set; }
        public double ConversionFactor { get; set; }
        public int Quantity { get; set; }
        public string QuantityToDisplay { get { return string.Concat(Quantity, " ", UnitOfMeasure); } set { QuantityToDisplay = value; } }
        public double RateInBaseUom { get; set; }
        public double RateInCurrentUom { get { return CalculateCurrentUomRate(RateInBaseUom, ConversionFactor); } set { RateInCurrentUom = value; } }
        public string RateInCurrentUomDisplay { get { return RateInCurrentUom.ToString() + " Rs/" + UnitOfMeasure; } set { RateInCurrentUomDisplay = value; } }
        public string StockInBaseUom { get; set; }
        public string AllocatedPerCustomerInBaseUom { get; set; }
        private double CalculateCurrentUomRate(double rateInBaseUom, double conversionFactor)
        {
            //Here one can apply promotion and offer
            return rateInBaseUom / conversionFactor;
        }
    }
}
