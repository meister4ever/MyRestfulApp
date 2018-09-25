using MyRestfulApp.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyRestfulApp.Controllers
{
    public class QuotationsController : ApiController
    {
        [Route("MyRestfulApp/Quotation/{currency}")]
        public async Task<IHttpActionResult> GetQuotation(string currency)
        {
            Quotation quotation = new Quotation();

            if (currency == "Pesos")
                quotation.SetCurrencyStrategy(new Pesos());
            else if (currency == "Real")
                quotation.SetCurrencyStrategy(new Real());
            else if (currency == "Dolar")
                quotation.SetCurrencyStrategy(new Dollar());
            else
                return NotFound();

            var response = await quotation.GetQuotation();

            if (response != null)
                return Ok(response);
            else
            {
                var msg = new HttpResponseMessage(HttpStatusCode.NotFound) { ReasonPhrase = "Request Not Found" };
                throw new HttpResponseException(msg);
            }
        }
    }
}
