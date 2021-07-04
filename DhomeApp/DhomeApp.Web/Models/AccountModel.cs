using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DhomeApp.Web.Models
{
    public class AccountModel
    {
        public int AccountId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int UserType { get; set; }

        public string Verify { get; set; }
    }
}
