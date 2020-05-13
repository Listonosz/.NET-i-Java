using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StronaCovid.Models
{
    //Representation of json file 
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { }

        public DbSet<Dataset> Records { get; set; }
    }
    public class Dataset
    {
        public string DataRep { get; set; }
        public uint day { get; set; }
        public uint month { get; set; }
        public uint year { get; set; }
        public int cases { get; set; }
        public int deaths { get; set; }
        public string countriesAndTerritories { get; set; }
        public string geoId { get; set; }
        public string countryterritoryCode { get; set; }
        public ulong? popData2018 { get; set; }
        public string ContinentExp { get; set; }
        public string newCases { get; set; }
    }
}
