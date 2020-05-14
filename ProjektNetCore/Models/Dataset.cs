using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Covid.Models
{
    public class Dataset
    {

     [Key]
        public uint ID { get; set; }
        public DateTime DataRep { get; set; }
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
    }

}

