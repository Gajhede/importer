using Importer.Configuration;
using Importer.Integration.DTO;
using System.Net.Http.Json;

namespace Importer.Integration
{
    internal class EnergyDataIntegration
    {
        const string baseApi = "https://api.energidataservice.dk/dataset/ImbalancePrice?";
        const string apiOffset = "offset=0&";
        const string apiIntervalStartBegin = "&start=";
        const string apiIntervalEndBegin = "&end=";
        const string apiSorting = "&sort=TimeUTC%20DESC";

        HttpClient api;
        EnergyDataIntegrationDTOParser parser;

        public EnergyDataIntegration()
        {
            api = new HttpClient();
            parser = new EnergyDataIntegrationDTOParser();
        }

        string BuildAPIUrl(IntegrationIntervalConfiguration apiConfig) =>
            $"{baseApi}" +
            $"{apiOffset}{apiIntervalStartBegin}" +
            $"{TimeUtil.ToApiFormat(apiConfig.StartTime)}" +
            $"{apiIntervalEndBegin}" +
            $"{TimeUtil.ToApiFormat(apiConfig.EndTime)}" +
            $"{apiSorting}";

        public async Task<List<ImbalancePrice>> FetchData(IntegrationIntervalConfiguration apiConfig)
        {
            string apiUrl = BuildAPIUrl(apiConfig);
            var response = await api.GetAsync(BuildAPIUrl(apiConfig));

            if (response.IsSuccessStatusCode)
            {
                return await parseToDbData(response);
            }

            else
            {
                throw new Exception();
            }
        }

        private async Task<List<ImbalancePrice>> parseToDbData(HttpResponseMessage response)
        {
            ImbalancePriceResponse dtoResponse = await response.Content.ReadFromJsonAsync<ImbalancePriceResponse>();
            List<ImbalancePrice> results = new();

            if (dtoResponse == null)
            {
                return results;
            }

            foreach (ImbalancePriceRecordDto record in dtoResponse.Records)
            {
                results.Add(parser.Parse(record));
            }

            return results;
        }
    }
}
