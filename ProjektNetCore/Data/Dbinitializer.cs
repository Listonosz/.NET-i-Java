using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Covid.Models;
using System.Net;
using Newtonsoft.Json;

namespace Covid.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CovidContext context)
        {
            context.Database.EnsureCreated();
            var wc = new WebClient();
            var json = wc.DownloadString("https://opendata.ecdc.europa.eu/covid19/casedistribution/json/");

            var data = JsonConvert.DeserializeObject<Records>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            uint iterator = 1;
            foreach (var d in data.records)
            {

                Dataset dataset = new Dataset()
                {
                    ID = iterator,
                    day = d.day,
                    month = d.month,
                    year = d.year,
                    DataRep = DateTime.Parse(d.year.ToString() + "-" + d.month.ToString() + "-" + d.day.ToString()),
                    cases = d.cases,
                    deaths = d.deaths,
                    countriesAndTerritories = d.countriesAndTerritories,
                    geoId = d.geoId,
                    countryterritoryCode = d.countryterritoryCode,
                    popData2018 = d.popData2018,
                    ContinentExp = d.ContinentExp
                };
                ++iterator;
                context.Datas.Add(dataset);
            };
            context.SaveChanges();
        }
    }
    }
