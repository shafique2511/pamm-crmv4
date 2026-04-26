using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class PAMMDbContextFactory : IDesignTimeDbContextFactory<PAMMDbContext>
{
    public PAMMDbContext CreateDbContext(string[] args)
    {
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        IConfiguration configuration = configurationBuilder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<PAMMDbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new PAMMDbContext(optionsBuilder.Options);
    }
}