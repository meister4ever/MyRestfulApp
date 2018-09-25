using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyRestfulApp.Models
{
    public class Quotation
    {
        private readonly List<string> _list = new List<string>();
        private Currency _currencyStrategy;

        public void SetCurrencyStrategy(Currency currency)
        {
            this._currencyStrategy = currency;
        }

        public async Task<List<string>> GetQuotation()
        {
            return await _currencyStrategy.GetQuotationAsync();
        }
    }
}