using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Match.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // A configuração aqui depende de como você armazena a connection string
            optionsBuilder.UseOracle("User Id=system;Password=oracle;Data Source=localhost:1521/XEPDB1");


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
