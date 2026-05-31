using Microsoft.EntityFrameworkCore;

namespace Importer.Repositories
{
    public class ImbalancePriceRepository
    {
        public Task<int> Persist(ImporterDbContext db, ImbalancePrice? res)
        {
            return db.Database.ExecuteSqlRawAsync(
            """
            INSERT OR IGNORE INTO ImbalancedPrices
            (
                TimestampUtc,
                Area,
                ImbalancePriceEUR,
                ImbalancePriceDKK
            )
            VALUES
            (
                {0},
                {1},
                {2},
                {3}
            )
            """,
            res.TimestampUtc,
            res.Area,
            res.ImbalancePriceEUR,
            res.ImbalancePriceDKK);
        }
    }
}
