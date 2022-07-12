using DatabaseRecordCreationModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBAccessor.Context
{
    public class RecordCreationContext : DbContext
    {
        public RecordCreationContext(DbContextOptions options) : base(options) { }
       
        public DbSet<ConfigurationData> ConfigurationsData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConfigurationData>().HasKey(c => new { c.Category, c.KeyName });
            base.OnModelCreating(modelBuilder);
        }
    }
}
 

