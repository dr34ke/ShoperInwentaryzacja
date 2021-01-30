using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Entities
{
    public class UsersShoperToken
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string ShopUrl { get; set; }
        public string Token { get; set; }
        public string ExpireDate { get; set; }
    }
}
