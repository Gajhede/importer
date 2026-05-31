using Importer;
using Importer.Configuration;
using Importer.Integration;
using Importer.Repositories;
using Microsoft.EntityFrameworkCore;

using var db = new ImporterDbContext();
EnergyDataIntegration energyDataIntegration = new EnergyDataIntegration();
UserConfigurationService configurationService = new UserConfigurationService();
ImbalancePriceRepository imbalancePriceRepository = new ImbalancePriceRepository();

IntegrationIntervalConfiguration apiConfig = configurationService.AskForApiConfiguration();
await UpdateDatabase(apiConfig);


async Task UpdateDatabase(IntegrationIntervalConfiguration apiConfig)
{
    List<ImbalancePrice> integrationResult = await energyDataIntegration.FetchData(apiConfig);
    Console.WriteLine($"interval from {apiConfig.StartTime.ToString("yyyy-MM-ddTHH:mm")} to {apiConfig.EndTime.ToString("yyyy-MM-ddTHH:mm")} provided {integrationResult.Count} results");

    foreach (var res in integrationResult)
    {
        await imbalancePriceRepository.Persist(db, res);
    }

    Console.WriteLine("Database updated with the fetched prices");
}

