using DhomeApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DhomeApp.Web.Models
{
    public class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public string Description { get; set; }
        public string AppointmentDate { get; set; }
        public string Address { get; set; }
        public int Valorization { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        public int PaymentMethodId { get; set; }
    }
}
