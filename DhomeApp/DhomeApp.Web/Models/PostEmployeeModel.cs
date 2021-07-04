using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DhomeApp.Web.Models
{
    public class PostEmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Todo trabajador debe registrar un nombre")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Todo trabajador debe registrar un apellido")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Todo trabajador debe registrar un DNI")]
        [StringLength(8, ErrorMessage = "El DNI debe tener un máximo de 8 dígitos.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Todo trabajador debe registrar un email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Todo trabajador debe registrar una descripcion")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Todo trabajador debe registrar un telefono")]
        public int Cellphone { get; set; }

        public int SpecialtyId { get; set; }

        public int DistrictId { get; set; }
    }
}
