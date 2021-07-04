using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DhomeApp.Web.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Dni { get; set; }
        
        public string Email { get; set; }

        public int Cellphone { get; set; }

        public string Description { get; set; }

        public int SpecialtyId { get; set; }

        public int DistrictId { get; set; }
    }

}
