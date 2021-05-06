using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DhomeApp.Web.Models
{
    public class PutCustomerModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un nombre")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El nombre del usuario debe tener entre 5 a 50 caracteres.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un apellido")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El apellido del usuario debe tener entre 5 a 50 caracteres.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un DNI")]
        [StringLength(8, ErrorMessage = "El DNI debe tener un máximo de 8 dígitos.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar una contraseña")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 a 20 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar una ciudad")]
        public string City { get; set; }
    }
}
