using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Motivate_jQuery.Models.Requests
{
    public class QuoteUpdateRequest : QuoteAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}