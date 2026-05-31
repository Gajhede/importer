namespace Importer.Integration.DTO
{
    internal class ImbalancePriceResponse
    {
        public int Total { get; set; }

        public string Filters { get; set; } = string.Empty;

        public int Limit { get; set; }

        public string Dataset { get; set; } = string.Empty;

        public List<ImbalancePriceRecordDto> Records { get; set; } = [];
    }
}
