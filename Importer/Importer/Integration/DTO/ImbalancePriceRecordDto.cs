namespace Importer.Integration.DTO
{
    public class ImbalancePriceRecordDto
    {
        public DateTime TimeUTC { get; set; }

        public DateTime TimeDK { get; set; }

        public string PriceArea { get; set; } = string.Empty;

        public decimal? SatisfiedDemand { get; set; }

        public decimal? ImbalancePriceEUR { get; set; }

        public decimal? ImbalancePriceDKK { get; set; }

        public decimal? SpotPriceEUR { get; set; }

        public int? DominatingDirection { get; set; }

        public decimal? aFRRUpMW { get; set; }

        public decimal? aFRRVWAUpEUR { get; set; }

        public decimal? aFRRVWAUpDKK { get; set; }

        public decimal? aFRRDownMW { get; set; }

        public decimal? aFRRVWADownEUR { get; set; }

        public decimal? aFRRVWADownDKK { get; set; }

        public decimal? mFRRMarginalPriceUpEUR { get; set; }

        public decimal? mFRRMarginalPriceUpDKK { get; set; }

        public decimal? mFRRMarginalPriceDownEUR { get; set; }

        public decimal? mFRRMarginalPriceDownDKK { get; set; }
    }
}
