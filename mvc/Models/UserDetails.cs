using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class UserDetails
    {
        [StringLength(7,MinimumLength =2,ErrorMessage ="Username length should be between 2 and 7")]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}