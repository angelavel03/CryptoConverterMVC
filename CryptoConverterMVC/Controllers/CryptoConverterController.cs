using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoConverterMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CryptoConverterMVC.Controllers
{
    public class CryptoConverterController : Controller
    {
        public IActionResult Index()
        {
            List<SelectListItem> ObjList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "BTC", Value = "BTC" },
                new SelectListItem { Text = "ETH", Value = "ETH" },
                new SelectListItem { Text = "XLM", Value = "XLM" },
                new SelectListItem { Text = "ADA", Value = "ADA" },
                new SelectListItem { Text = "DOGE", Value = "DOGE" },
                new SelectListItem { Text = "SOL", Value = "SOL" },
                new SelectListItem { Text = "SHIB", Value = "SHIB" }
             
            };
            
            ViewBag.currencies = ObjList;
            return View();
        }

        //Assigning generic list to ViewBag
        // ovde na ist nacin mozat da se dodadat uste cripto vrednosti

        [HttpGet]
        public JsonResult convert(string currency)
        {
           
            var baseUrl = "https://api.coinbase.com/v2/";
            var requestUrl = $"exchange-rates?currency={currency}";
            var response = new Currencies { };
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            //HTTP GET
             var responseFromAPI = client.GetAsync(requestUrl).Result;
             if (responseFromAPI.IsSuccessStatusCode)
             {
                 var responseContent = responseFromAPI.Content.ReadAsStringAsync();
                 response = JsonConvert.DeserializeObject<Currencies>(responseContent.Result);
             }
            return Json(response.data.rates["USD"]);
        }
    }
}

// ova e nadvoresno api so se koristi za konverzija na bilo koja kripto curency vo site drugi currencies
// ne se plaka i moze da se koristi bez licenca i e koristena od drugi softveri

