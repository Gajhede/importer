using Importer.Integration.DTO;

namespace Importer.Integration
{
    internal class EnergyDataIntegrationDTOParser
    {
        public ImbalancePrice Parse(ImbalancePriceRecordDto record)
        {
            return new ImbalancePrice(record.TimeUTC, Enum.Parse<PriceArea>(record.PriceArea), record.ImbalancePriceEUR, record.ImbalancePriceDKK);
        }
    }
}
