using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DhomeApp.Entity
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del usuario debe tener entre 5 a 50 caracteres.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un apellido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El apellido del usuario debe tener entre 5 a 50 caracteres.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un DNI")]
        [StringLength(8, ErrorMessage = "El DNI debe tener un máximo de 8 dígitos.")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar una ciudad")]
        public int IdCity { get; set; }
        
        [Required(ErrorMessage = "Todo cliente debe registrar una cuenta")]
        public int IdAccount { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un telefono")]
        public int Cellphone { get; set; }

        [Required(ErrorMessage = "Todo cliente debe registrar un distrito")]
        public int IdDistrict { get; set; }


    }
}
