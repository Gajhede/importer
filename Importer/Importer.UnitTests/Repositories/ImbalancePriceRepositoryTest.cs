using Microsoft.EntityFrameworkCore;

namespace Importer.UnitTests.Repositories
{
    public class ImbalancePriceRepositoryTest
    {
        [Fact]
        public async Task Persist_OneEntry_OneInserted()
        {
            using ImporterDbContext db = await IntegrationTestUtil.SetupTempDb();
            Importer.Repositories.ImbalancePriceRepository repository = new();

            await repository.Persist(db, new ImbalancePrice(new DateTime(2024, 5, 30), PriceArea.DK1, 300m, 200m));

            Assert.Equal(
                1,
                await db.ImbalancedPrices.CountAsync());
        }

        [Fact]
        public async Task Persist_TwoDuplicates_DuplicateNotInserted()
        {
            using ImporterDbContext db = await IntegrationTestUtil.SetupTempDb();
            Importer.Repositories.ImbalancePriceRepository repository = new();

            await repository.Persist(db, new ImbalancePrice(new DateTime(2024, 5, 30), PriceArea.DK1, 300m, 200m));
            await repository.Persist(db, new ImbalancePrice(new DateTime(2024, 5, 30), PriceArea.DK1, 300m, 200m));

            Assert.Equal(
                1,
                await db.ImbalancedPrices.CountAsync());
        }

        [Fact]
        public async Task Persist_SameTimeDifferentAreas_BothInserted()
        {
            using ImporterDbContext db = await IntegrationTestUtil.SetupTempDb();
            Importer.Repositories.ImbalancePriceRepository repository = new();

            await repository.Persist(db, new ImbalancePrice(new DateTime(2024, 5, 30), PriceArea.DK1, 300m, 200m));
            await repository.Persist(db, new ImbalancePrice(new DateTime(2024, 5, 30), PriceArea.DK2, 300m, 200m));

            Assert.Equal(
                2,
                await db.ImbalancedPrices.CountAsync());
        }

        [Fact]
        public async Task Persist_DifferentTimeSameAreas_BothInserted()
        {
            using ImporterDbContext db = await IntegrationTestUtil.SetupTempDb();
            Importer.Repositories.ImbalancePriceRepository repository = new();

            await repository.Persist(db, new ImbalancePrice(new DateTime(2024, 5, 30), PriceArea.DK1, 300m, 200m));
            await repository.Persist(db, new ImbalancePrice(new DateTime(2024, 5, 28), PriceArea.DK1, 300m, 200m));

            Assert.Equal(
                2,
                await db.ImbalancedPrices.CountAsync());
        }
    }
}
