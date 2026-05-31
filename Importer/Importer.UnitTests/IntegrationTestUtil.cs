using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Importer.UnitTests
{
    internal class IntegrationTestUtil
    {
        public static async Task<ImporterDbContext> SetupTempDb()
        {
            var dbPath = Path.GetTempFileName();

            var options =
                new DbContextOptionsBuilder<ImporterDbContext>()
                    .UseSqlite($"Data Source={dbPath}")
                    .Options;
            var context = new ImporterDbContext(options);

            await context.Database.EnsureCreatedAsync();
            return context;
        }
    }
}
