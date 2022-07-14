using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthWebApp.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public int Password { get; set; }
    }
}