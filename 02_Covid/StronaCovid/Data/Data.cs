using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using ChoETL;
using System.Text;

namespace StronaCovid.Data
{
    public class Data
    {
        public void parsing()
        {
            string namecsv = "stats.csv";
            string namejson = "stats.json";
            string link = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_daily_reports/05-10-2020.csv";
            string filePath = Directory.GetCurrentDirectory();
            string filecsv = filePath + namecsv;
            string filejson = filePath + namejson;

            using (var client = new WebClient())
            {
                client.DownloadFile(link, filecsv);
            }
        
            StringBuilder sb = new StringBuilder();
            using (var p = new ChoCSVReader(filecsv).WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(filejson))
                    w.Write(p);
            }
        }
    }
}
