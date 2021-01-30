using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ShoperInwentaryzacja.Models
{
    public class ShoperAuthResponse
    {
        public ShoperAuthResponse()
        {

        }
        public ShoperAuthResponse(string content)
        {
            ShoperAuthResponse shoper = JsonConvert.DeserializeObject<ShoperAuthResponse>(content);
            this.access_token = shoper.access_token;
            this.expires_in = shoper.expires_in;
            this.expire_date = (DateTime.Now.Subtract(DateTime.MinValue).TotalSeconds + Convert.ToDouble(expires_in)).ToString();
        }
        public string access_token { get; set; }
        public string expires_in {get;set;}
        public string expire_date { get; set; }
    }
}
