using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DhomeApp.Web.Models
{
    public class PutEmployeeModel
    {
        public int EmployeeId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Dni { get; set; }
    }
}
