using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StronaCovid.Models;
using System.Net;
using Newtonsoft.Json;

namespace StronaCovid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }
       /*
        public IActionResult Index()
        {
            return View();
        }
        */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            //Deserialization of json

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://opendata.ecdc.europa.eu/covid19/casedistribution/json/");
                var data = JsonConvert.DeserializeObject<Records>(json, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                return View(data);
            }
                
            //var json = wc.DownloadString("C:/Users/Student241165/source/repos/.NET-i-Java/02_Covid/StronaCovid/wwwroot/dataset/data.json");
           // var data = JsonConvert.DeserializeObject<Data>(json);
           // return View(data);
        }
        
    }
}
