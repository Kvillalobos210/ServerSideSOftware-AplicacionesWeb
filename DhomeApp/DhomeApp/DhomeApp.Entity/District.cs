using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhomeApp.Entity
{
    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }

        
        //Foreing Key
        public virtual ICollection<Customer> Customers { get; set; }
        
        //Foreing Key
        public virtual ICollection<Employee> Employees { get; set; }
        
    }
}
