using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using DotNetEnv;

namespace Optima.Infrastructure.DataAcess
{
    public class OptimaDbContextFactory : IDesignTimeDbContextFactory<OptimaDbContext>
    {
        public OptimaDbContext CreateDbContext(string[] args)
        {
            Env.Load();

            var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            var cs = config.GetConnectionString("SqlServer");
            if (string.IsNullOrWhiteSpace(cs))
                throw new InvalidOperationException("Connection string 'SqlServer' não encontrada.");

            var options = new DbContextOptionsBuilder<OptimaDbContext>()
                .UseSqlServer(cs)
                .Options;

            return new OptimaDbContext(options);
        }
    }
}
