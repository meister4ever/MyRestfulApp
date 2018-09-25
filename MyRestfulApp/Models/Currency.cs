using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyRestfulApp.Models
{
    public abstract class Currency
    {
        public abstract Task<List<string>> GetQuotationAsync();
    }
}