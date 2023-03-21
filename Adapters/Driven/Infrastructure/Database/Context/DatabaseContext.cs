using System;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapters.Driven.Infrastructure.Database.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public virtual DbSet<Squad> Squads { get; private set; }

        private string ParseDSN()
        {
            string host = Environment.GetEnvironmentVariable("DB_HOST");
            string user = Environment.GetEnvironmentVariable("DB_USER");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string name = Environment.GetEnvironmentVariable("DB_NAME");
            return $"Host={host};Username={user};Password={password};Database={name}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(ParseDSN());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Squad>().
            HasKey(s => s.Id);
        }
    }
}