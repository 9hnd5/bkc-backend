using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bkc_backend.Api.Model
{
    public class RejectBkcModel
    {
        [Required]
        public string BookerId { get; set; }
        [Required]
        public string ReasonReject { get; set; }
    }
}
