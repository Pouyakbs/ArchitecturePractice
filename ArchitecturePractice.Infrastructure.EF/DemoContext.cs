using ArchitecturePractice.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ArchitecturePractice.Infrastructure.EF
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public override int SaveChanges()
        {
            var entries = this.ChangeTracker.Entries().ToList();
            foreach (var item in entries)
            {
                Logs logs = new Logs()
                {
                    Operation = item.State.ToString(),
                    TableName = item.Entity.ToString(),
                    Data = JsonConvert.SerializeObject(item.Entity)
                };
                Logs.Add(logs);
            }
            return base.SaveChanges();
        }
    }
}
