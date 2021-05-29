using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhomeApp.Entity
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }

        public string PaymentMethodName { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
