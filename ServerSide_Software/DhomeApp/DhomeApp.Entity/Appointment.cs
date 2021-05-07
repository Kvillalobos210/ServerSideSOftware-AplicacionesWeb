using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhomeApp.Entity
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Toda cita debe presentar un cliente")]
        public int CustomerId { get; set; } 

        [Required(ErrorMessage = "Toda cita debe presentar un trabajador")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Toda cita debe presentar una descripción")]
        [StringLength(200, ErrorMessage = "La descripción de la cita debe tener como máximo 200 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Toda cita debe presentar una fecha")]
        public string AppointmentDate { get; set; }

        [Required(ErrorMessage = "Toda cita debe presentar una dirección")]
        [StringLength(200, ErrorMessage = "La dirección donde se realizará el servicio debe tener como máximo 200 caracteres.")]
        public string Address { get; set; }

        public int Valorization { get; set; }

        [Required(ErrorMessage = "Toda cita debe tener un estado (realizado, confirmado, pendiente)")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Toda cita debe presentar un método de pago (efectivo o tarjeta de credito)")]
        public int IdPaymentMethod { get; set; }

    }
}
