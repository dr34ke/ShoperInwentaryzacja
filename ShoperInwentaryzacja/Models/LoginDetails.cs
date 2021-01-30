using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShoperInwentaryzacja.Models
{
    public class LoginDetails
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string ShopUrl { get; set; }
        public string Token { get; set; }
    }

}
