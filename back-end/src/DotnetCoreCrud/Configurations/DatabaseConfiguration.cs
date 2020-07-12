using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DotnetCoreCrud.Configurations
{
    public class DatabaseConfiguration
    {
        public static string ConnectionString { get; private set; }

        public static void Configure(IConfiguration configuration)
        {
            try
            {
                using (var stream = File.OpenRead("../../.env"))
                {
                    DotNetEnv.Env.Load(stream);
                }
            } catch { }
            ConnectionString = string.Format(
                configuration.GetConnectionString("DefaultConnection"),
                Environment.GetEnvironmentVariable("DB_HOST"),
                Environment.GetEnvironmentVariable("DB_NAME"),
                Environment.GetEnvironmentVariable("DB_USER"),
                Environment.GetEnvironmentVariable("DB_PASSWORD")
            );
        }
    }
}
