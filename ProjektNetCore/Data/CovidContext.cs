using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covid.Models;
using System.Net;
using Newtonsoft.Json;

namespace Covid.Data
{
    public class CovidContext : DbContext
    {
        private object month;

        public DbSet<Dataset> Datas { get; set; }
        // public DbSet<Records> Records { get; set; }
        
        public CovidContext()
        { }
        
        public CovidContext(DbContextOptions<CovidContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CovidDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        */
    }
}
