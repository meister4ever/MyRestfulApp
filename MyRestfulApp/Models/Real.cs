using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyRestfulApp.Models
{
    public class Real : Currency
    {
        public override Task<List<string>> GetQuotationAsync()
        {
            var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Unauthorized access" };
            throw new HttpResponseException(msg);
        }
    }
}