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
        public string Token { get => _Token;
            set
            {
                Token token = JsonConvert.DeserializeObject<Token>(value);
                _Token = token.access_token;
                DateTime = DateTime.Now.AddSeconds(Double.Parse(token.expires_in));
            }
        }
        public DateTime DateTime { get; set; }
        private string _Token { get; set; }
    }
    public class Token
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }

    public class UserData
    { 
        public string Token { get; set; }
        public string ExpireDate { get; set; }
        public string ShopUrl { get; set; }
        public bool IsValid { get; set; }
    }


}
