using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Text_Name_Search.Models
{
    public class Names
    {
        [Required(ErrorMessage ="This field is required.")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
      
    }
}