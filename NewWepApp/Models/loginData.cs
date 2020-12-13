using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewWepApp.Models
{
    public class loginData
    {
        [Required(ErrorMessage = "*")]
        public string email { get; set; }
        
        [Required(ErrorMessage = "*")]

        public string password { get; set; }
    }
}