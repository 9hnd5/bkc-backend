using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Model
{
    public class DeclineBkcModel
    {
        public string BookerId { get; set; }
        public string Reason { get; set; }
    }
}
