using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerCore.Data
{
    public class LoggerDbContextFactory : IDesignTimeDbContextFactory<LoggerDbContext>
    {
        private static string _connectionString;
        public LoggerDbContext CreateDbContext(string[] args = null)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                LoadConnectionString();
            }

            var builder = new DbContextOptionsBuilder<LoggerDbContext>();
            builder.UseSqlServer(_connectionString);

            return new LoggerDbContext(builder.Options);
        }

        private static void LoadConnectionString()
        {
            LogConfiguration.Instance.LoadConfiguration(new ConfigurationBuilder().AddJsonFile("appconfig.json"));
            _connectionString = LogConfiguration.Instance.DB?.ConnectionString ?? "";
        }
    }
}
