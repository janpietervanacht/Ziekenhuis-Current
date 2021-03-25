using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Ziekenhuis.DataAccess.ApplicDbContext;

namespace UnitTest.ApplicDbContextInMemory // Naam Namespace <> ApplicationDbContext
{
    public static class InternalDbGenerator
    {
        public static ApplicationDbContext CreateDbContext()
        {
            var dbContext = GetDbContext();  // aanmaken initiele interne database
            return dbContext;
        }

        /// <summary>
        /// Aanmaken initiele in-memory database
        /// </summary>
        /// <returns></returns>
        private static ApplicationDbContext GetDbContext()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .EnableSensitiveDataLogging()
                .UseSqlite(connection)
                .Options;

            var dbContext = new ApplicationDbContext(options);

            dbContext.Database.OpenConnection();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }

}
