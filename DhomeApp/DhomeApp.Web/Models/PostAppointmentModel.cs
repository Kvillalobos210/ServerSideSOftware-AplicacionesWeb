using DhomeApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DhomeApp.Web.Models
{
    public class PostAppointmentModel
    {
        public int AppointmentId { get; set; }

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

        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
