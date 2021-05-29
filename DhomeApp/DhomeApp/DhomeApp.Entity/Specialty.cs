using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhomeApp.Entity
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        public string SpecialtyName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
