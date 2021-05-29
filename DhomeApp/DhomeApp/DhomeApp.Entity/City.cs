using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhomeApp.Entity
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        //Foreing Key
        public virtual ICollection<District> Districts { get; set; }
    }
}
