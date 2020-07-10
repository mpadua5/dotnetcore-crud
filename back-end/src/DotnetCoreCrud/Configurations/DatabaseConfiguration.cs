using System;
using Microsoft.Extensions.Configuration;

namespace DotnetCoreCrud.Configurations
{
    public class DatabaseConfiguration
    {
        public static string ConnectionString { get; private set; }

        public static void Configure(IConfiguration configuration)
        {
            ConnectionString = string.Format(
                configuration.GetConnectionString("DefaultConnection"),
                Environment.GetEnvironmentVariable("MYSQL_HOST"),
                Environment.GetEnvironmentVariable("MYSQL_PORT"),
                Environment.GetEnvironmentVariable("MYSQL_DB"),
                Environment.GetEnvironmentVariable("MYSQL_USER"),
                Environment.GetEnvironmentVariable("MYSQL_PASSWORD")
            );
        }
    }
}
