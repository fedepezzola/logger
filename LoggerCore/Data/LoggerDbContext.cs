using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerCore.Data
{
    public class LoggerDbContext : DbContext
    {
        public LoggerDbContext(DbContextOptions<LoggerDbContext> options) : base(options)
        {
        }

        public DbSet<Logs> Logs { get; set; }

        public DbSet<LogTypes> LogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>()
                .HasOne(x => x.LogType)
                .WithMany(x => x.Logs)
                .HasForeignKey(x => x.Type);

            modelBuilder.Entity<LogTypes>().HasData(
                new LogTypes() { Id = "E", Description = "Error" },
                new LogTypes() { Id = "W", Description = "Warning" },
                new LogTypes() { Id = "M", Description = "Message" }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
