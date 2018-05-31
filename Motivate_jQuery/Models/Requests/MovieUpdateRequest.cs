using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Motivate_jQuery.Models.Requests
{
    public class MovieUpdateRequest : MovieAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}