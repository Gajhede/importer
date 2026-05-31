using Importer.Integration.DTO;

namespace Importer.UnitTests.Integration
{
    public class EnergyDataIntegrationDTOParserTest
    {
        [Fact]
        public void Parse_ValidObject_Success()
        {
            var parser = new Importer.Integration.EnergyDataIntegrationDTOParser();

            ImbalancePriceRecordDto validObject = new ImbalancePriceRecordDto();
            validObject.TimeUTC = new DateTime(2024, 5, 30);
            validObject.PriceArea = "DK1";
            validObject.ImbalancePriceEUR = 300m;
            validObject.ImbalancePriceDKK = 200m;

            var result = parser.Parse(validObject);

            Assert.Equal(200m, result.ImbalancePriceDKK);
            Assert.Equal(300m, result.ImbalancePriceEUR);
            Assert.Equal(PriceArea.DK1, result.Area);
            Assert.Equal(new DateTime(2024, 5, 30), result.TimestampUtc);
        }

        [Fact]
        public void Parse_UnsupportedPriceArea_ThrowsException()
        {
            var parser = new Importer.Integration.EnergyDataIntegrationDTOParser();

            ImbalancePriceRecordDto invalidObject = new ImbalancePriceRecordDto();
            invalidObject.TimeUTC = new DateTime(2024, 5, 30);
            invalidObject.PriceArea = "DK3";
            invalidObject.ImbalancePriceEUR = 300m;
            invalidObject.ImbalancePriceDKK = 200m;

            Assert.Throws<ArgumentException>(() => parser.Parse(invalidObject));
        }
    }
}
