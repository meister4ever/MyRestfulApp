using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyRestfulApp.Models
{
    public class Pesos : Currency
    {
        public override Task<List<string>> GetQuotationAsync()
        {
            var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Unauthorized access" };
            throw new HttpResponseException(msg);
        }
    }
}