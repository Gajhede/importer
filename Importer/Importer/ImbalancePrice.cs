namespace Importer
{
    internal class ImbalancePrice(DateTime TimestampUtc, PriceArea Area, decimal? ImbalancePriceEUR, decimal? ImbalancePriceDKK)
    {
        public DateTime TimestampUtc { get; set; } = TimestampUtc;
        public PriceArea Area { get; set; } = Area;
        public decimal? ImbalancePriceEUR { get; set; } = ImbalancePriceEUR;
        public decimal? ImbalancePriceDKK { get; set; } = ImbalancePriceDKK;

        public override string ToString()
        {
            return $"time: {TimestampUtc}, area: {Area}, EUR: {ImbalancePriceEUR}, DKK: {ImbalancePriceDKK}";
        }
    }
}
