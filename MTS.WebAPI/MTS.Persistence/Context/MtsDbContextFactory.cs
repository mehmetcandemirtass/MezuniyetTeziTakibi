using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MTS.Persistence.Context
{
    public class MtsDbContextFactory : IDesignTimeDbContextFactory<MtsDbContext>
    {
        public MtsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MtsDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-I2E1T9B\\MSSQLSERVER01;Database=MezuniyetTakip;Trusted_Connection=True;TrustServerCertificate=True;");

            return new MtsDbContext(optionsBuilder.Options);
        }
    }
}