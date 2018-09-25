using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MyRestfulApp.Models
{
    public class Dollar : Currency
    {
        public override async Task<List<string>> GetQuotationAsync()
        {
            var uri = new Uri("http://www.bancoprovincia.com.ar/Principal/Dolar");
            using (WebClient webClient = new WebClient())
            {
                return await Task.Run(() => JsonConvert.DeserializeObject<List<string>>(
                    webClient.DownloadString(uri)));
            }
        }
    }
}