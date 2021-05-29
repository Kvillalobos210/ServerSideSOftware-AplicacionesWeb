using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DhomeApp.Web.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
        
        public string Dni { get; set; }

        public int DistrictId { get; set; }
    }
}
