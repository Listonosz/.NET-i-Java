using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StronaCovid.Models
{
    public class Statistics
    {
        public string dataRep { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int cases { get; set; }
        public int deaths { get; set; }
        public string countriesAndTerritories { get; set; }
        public string countryterritoryCode { get; set; }
        public long popData2018 { get; set; }
        public string ContinentExp { get; set; }

    }
}
