using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Mlpp.Infrastructure.Storage.Mlpp;
using System.IO;

namespace Mlpp.Migrations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MlppContext>
    {
        public MlppContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MlppContext>();

            var connectionString = configuration.GetConnectionString("Database:ConnectionString");

            builder.UseSqlServer("Data Source=.;Initial Catalog=Mlpp;Integrated Security=SSPI;", b => b.MigrationsAssembly("Mlpp"));

            return new MlppContext(builder.Options);
        }
    }
}
